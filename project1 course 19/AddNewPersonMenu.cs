using ContactsBusinessLayer;
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
        clsPeopleBusinessLayer _People;
        public AddNewPersonMenu(int PeopleID)
        {
            InitializeComponent();

            _PeopleID = PeopleID;

            if (_PeopleID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }
        private void _FillCountriesInComoboxBox()
        {
            // 1. جلب بيانات الدول من طبقة الأعمال
            DataTable dtCountries = clsCountry.GetAllCountries();

            // 2. ربط الـ DataTable بالـ ComboBox مباشرة
            cbCountry.DataSource = dtCountries;
            cbCountry.DisplayMember = "CountryName"; // اسم عمود الدولة الذي يظهر للمستخدم
            cbCountry.ValueMember = "CountryID";     // اسم عمود الـ ID في الجدول

            // تحديد العُنصر الأول افتراضياً إذا كانت القائمة تحتوي دولاً
            if (cbCountry.Items.Count > 0)
            {
                cbCountry.SelectedIndex = 0;
            }
        }

        private void _LoadData()
        {
            _FillCountriesInComoboxBox();
            cbCountry.SelectedIndex = 1;

            if (_Mode == enMode.AddNew)
            {
                AddNewTitletxt.Text = "Add New Contact";
                _People = new clsPeopleBusinessLayer();
                return;
            }
            _People=clsPeopleBusinessLayer.Find(_PeopleID);

            if (_People == null)
            {
                MessageBox.Show("This Form will be closed because No Person  with ID Found");
                this.Close();
                return;
            }
        }
        private void AddNewPersonMenu_Load(object sender, EventArgs e)
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            // 2. ربط البيانات بالـ ComboBox في طبقة الواجهة (UI)
            cbCountry.DataSource = dtCountries;
            cbCountry.DisplayMember = "CountryName"; // اسم العمود في الجدول
            cbCountry.ValueMember = "CountryID";     // اسم عمود الـ ID في الجدول

            _LoadData();
        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int countryID = Convert.ToInt32(cbCountry.SelectedValue);

            _People.FirstName = textBoxFirstName.Text;
            _People.SecondName = textBoxSecondName.Text;
            _People.ThirdName = textBoxthirdName.Text;
            _People.LastName = textBoxLastName.Text;
            _People.Email = txtboxEmail.Text;
            _People.Phone = txtboxPhone.Text;
            _People.Address = textBoxAddress.Text;
            _People.NationalNo = textBoxNationalNo.Text;
            _People.DateOfBirth = BirthBox.Value;
            _People.CountryID = countryID;

            if (pictureBox1.ImageLocation != null) { _People.ImagePath = pictureBox1.ImageLocation; }
            else
                _People.ImagePath = "";

            if (_People.Save())
                MessageBox.Show("Data  Saved Successfully");
            else
                MessageBox.Show("Error: Data is not Saved Successfully.");

            _Mode = enMode.Update;
            AddNewTitletxt.Text = "Edit Person with ID = " + _People.ID;
            


        }
    }
}
