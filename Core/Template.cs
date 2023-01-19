﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tåg_project.Properties;

namespace Tåg_project
{
    public partial class Template : Form
    {
        private Form _currentChildForm;
        private string path = null;
        public Template()
        {
            InitializeComponent();
            buildComponents();
            //openChildForm("Start");
        }

        private void buildComponents()
        {
            this.Icon = Resources.vov_logo;
            pboxLogo.Image = Resources.vov;
        }

        //private void openChildForm(string formName)
        //{
        //    var parentForm = mainPanel;
        //    _currentChildForm?.Close();
        //    if (formName == "Home")
        //    {
        //        _currentChildForm = new Home(path);
        //    }
        //    else if (formName == "Start")
        //    {
        //        _currentChildForm = new StartForm();
        //    }
        //
        //    _currentChildForm.Owner = this;
        //    Utils.OpenChildForm(_currentChildForm, parentForm);
        //}

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
