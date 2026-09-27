using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1_course_19
{
    public partial class AddNewPersonMenu : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PeopleID;
        AddNewPersonMenu _People;
        public AddNewPersonMenu(int PeopleID)
        {
            InitializeComponent();

            _PeopleID = PeopleID;

            if (_PeopleID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsPeopleBusinessLayer.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }

        }
        private void _LoadData()
        {
           
        }
        private void AddNewPersonMenu_Load(object sender, EventArgs e)
        {
            
        }

    }
}
