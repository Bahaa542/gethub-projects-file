using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace project1_course_19
{
    public partial class ManagePeople : Form
    {
        private DataTable _dtPeople;


        public ManagePeople()
        {
            InitializeComponent();

        }
       
        private void _RefreshContactsList()
        {
            _dtPeople = clsPeopleBusinessLayer.GetAllPeople();
            DgvAllPeople.DataSource = _dtPeople;
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";

            if (cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtFilterValue.Visible = false;
                if (_dtPeople != null)
                    _dtPeople.DefaultView.RowFilter = "";
            }
            else
            {
                txtFilterValue.Visible = true;
                
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
       {
          if (_dtPeople == null) return;

            string searchValue = txtFilterValue.Text.Trim().Replace("'", "''");

            if (cbFilterBy.SelectedItem == null) return;

            string selectedColumn = cbFilterBy.SelectedItem.ToString();

            if (string.IsNullOrEmpty(searchValue))
            {
                _dtPeople.DefaultView.RowFilter = "";
                return;
            }

            switch (selectedColumn)
            {
                case "Person ID":
                    if (int.TryParse(searchValue, out int id))
                        _dtPeople.DefaultView.RowFilter = $"PersonID = {id}";
                    
                    break;

                case "National No.":
                    _dtPeople.DefaultView.RowFilter = $"NationalNo LIKE '{searchValue}%'";
                    break;

                case "First Name":
                    _dtPeople.DefaultView.RowFilter = $"FirstName LIKE '{searchValue}%'";
                    break;

                case "Last Name":
                    _dtPeople.DefaultView.RowFilter = $"LastName LIKE '{searchValue}%'";
                    break;

                case "Phone":
                    _dtPeople.DefaultView.RowFilter = $"Phone LIKE '{searchValue}%'";
                    break;

                case "Email":
                    _dtPeople.DefaultView.RowFilter = $"Email LIKE '{searchValue}%'";
                    break;

                case "Nationality":
                    _dtPeople.DefaultView.RowFilter = $"CountryName LIKE '{searchValue}%'";
                    break;

                case "Gendor":
                    _dtPeople.DefaultView.RowFilter = $"GendorCaption LIKE '{searchValue}%'";
                    break;

                default:
                    _dtPeople.DefaultView.RowFilter = "";
                    break;
            }
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            AddNewPersonMenu AddNewPerson = new AddNewPersonMenu(-1);
            AddNewPerson.ShowDialog();

        }
    }
}
