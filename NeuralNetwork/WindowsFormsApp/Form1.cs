using GalaxyFootball.RobotBrain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        #region Data
        private Dictionary<string, RobotDataset> m_datasets = new Dictionary<string, RobotDataset>();

        int m_dataset_number = 1;
        int m_dataset_display_index = 0;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region -  MENU  -

        private void defendMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewDefenceDataset();
        }

        private void shootingMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewShootingDataset();
        }


        private void passingToMostForwardTeammateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewLongPassDataset();
        }

        #endregion


        #region -  Toolbar  -
        private void toolNextDataset_Click(object sender, EventArgs e)
        {
            ShowNextData();
        }

        private void toolNextPositiveDataSet_Click(object sender, EventArgs e)
        {
            ShowNextPositiveData();
        }

        private void toolPreviousPositiveDataSet_Click(object sender, EventArgs e)
        {
            ShowPreviousPositiveData();
        }
        private void toolComboBoxDatasetsSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_dataset_display_index = 0;
            RenderFieldAndDisplaySceneData();
        }

        private void ShowNextData()
        {
            SelectNextDataset(false); 
            RenderFieldAndDisplaySceneData();
        }

        private void ShowNextPositiveData()
        {
            SelectNextDataset(true);
            RenderFieldAndDisplaySceneData();
        }

        private void SelectNextDataset(bool only_positives)
        {
            var dataset = GetSelectedDataset();
            if (dataset != null)
            {
                bool stop = false;
                while (!stop)
                {
                    if (m_dataset_display_index < (dataset.Count-1))
                    {
                        m_dataset_display_index++;
                        if (!only_positives) stop = true;
                    }
                    else
                    {
                        stop = true;
                    }

                    if (only_positives && dataset.GetDataset(m_dataset_display_index).HasPositiveTarget())
                    {
                        stop = true;
                    }
                }
            }                
        }

        private void RenderFieldAndDisplaySceneData()
        {
            DisplaySceneData();
            //splitContainer3.Panel1.Invalidate();
            //splitContainer3.Panel1.Update();
            splitContainer3.Panel1.Refresh();
        }

        private void DisplaySceneData()
        {
            // show distances and info about scene at right side of window}
            var field   = GetFieldFromDataset();
            var target  = GetRobotBrainTargetsFromDataset();

            propertyGrid_fieldscene.PropertySort = PropertySort.Categorized;
            propertyGrid_fieldscene.SelectedObject = FieldSceneProperties.Get(field, target);
        }

        private void toolPreviousDataset_Click(object sender, EventArgs e)
        {
            ShowPreviousData();
        }

        private void ShowPreviousData()
        {
            SelectPreviousDataset(false);
            RenderFieldAndDisplaySceneData();
        }

        private void ShowPreviousPositiveData()
        {
            SelectPreviousDataset(true);
            RenderFieldAndDisplaySceneData();
        }

        private void SelectPreviousDataset(bool only_positives)
        {
            var dataset = GetSelectedDataset();
            if (dataset != null)
            {
                bool stop = false;
                while (!stop)
                {
                    if (m_dataset_display_index > 0)
                    {
                        m_dataset_display_index--;
                        if (!only_positives) stop = true;
                    }
                    else
                    {
                        stop = true;
                    }

                    if (only_positives && dataset.GetDataset(m_dataset_display_index).HasPositiveTarget())
                    {
                        stop = true;
                    }
                }
            }
        }

        #endregion

        #region -  Create Datasets  -
        private void CreateNewShootingDataset()
        {
            int iterations = 1000;

            var simulate_shooting = DataSetFactory.GetCreator(DataSetFactory.Simulation.Shooting);
            var dataset = simulate_shooting.GetDataSet(iterations);
            var name = string.Format("Shooting_DataSet_{0}", m_dataset_number++);
            StoreDataset(name, dataset);
        }

        private void CreateNewLongPassDataset()
        {
            int iterations = 1000;

            var simulate_longpass = DataSetFactory.GetCreator(DataSetFactory.Simulation.LongPass);
            var dataset = simulate_longpass.GetDataSet(iterations);
            var name = string.Format("LongPass_DataSet_{0}", m_dataset_number++);
            StoreDataset(name, dataset);
        }

        private void CreateNewDefenceDataset()
        {
            int iterations = 1000;
            var simulation = DataSetFactory.GetCreator(DataSetFactory.Simulation.Defend);
            var dataset = simulation.GetDataSet(iterations);
            var name = string.Format("Defende_DataSet_{0}", m_dataset_number++);
            StoreDataset(name, dataset);
        }

        private void StoreDataset(string name, RobotDataset dataset)
        {
            m_datasets.Add(name, dataset);

            toolComboBoxDatasetsSelection.Items.Add(name);

            toolComboBoxDatasetsSelection.SelectedItem = name;
        }
        #endregion

        #region Logging
        private void LogMessage(string format, params object[] args)
        {
            var str = string.Format(format, args);
            listBox_logging.Items.Insert(0, str);
        }

        #endregion

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // if mode is dataset
            var field = GetFieldFromDataset();
            // if mode is game simulation

            // if trainign mode....

            var field_renderer = new RendererField(graphics, field);


        }

        private RobotDataset GetSelectedDataset()
        {
            if (m_datasets.Count == 0) return null;
            if (toolComboBoxDatasetsSelection.SelectedItem == null) return null;
            var selected_dataset = toolComboBoxDatasetsSelection.SelectedItem.ToString();
            if (m_datasets.ContainsKey(selected_dataset))
            {
                return m_datasets[selected_dataset];
            }
            return null;
        }
        private FieldScene GetFieldFromDataset()
        {
            var dataset = GetSelectedDataset();

            if (dataset != null &&
                m_dataset_display_index >= 0 &&
                m_dataset_display_index < dataset.Count ) 
            {
                var field = new FieldScene();

                // Get Raw values
                var set = dataset.GetDataset(m_dataset_display_index);

                // Convert into scene attributes
                var input = new InputValues(set.Values);

                // Set attributes to field
                field.SetSceneFromDataset(input);

                return field;
            }
            return null;
        }

        private OutputValues GetRobotBrainTargetsFromDataset()
        {
            var dataset = GetSelectedDataset();

            if (dataset != null &&
                m_dataset_display_index >= 0 &&
                m_dataset_display_index < dataset.Count)
            {
                // Get Raw values
                var set = dataset.GetDataset(m_dataset_display_index);

                // Convert into targets for training
                var targets = new OutputValues(set.Targets);
                return targets;
            }
            return null;
        }

    }
}
