using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleDataAccessLayer;

namespace PeopleBusinessLayer
{
    public class clsPeopleBusinessLayer
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public string NationalNo { set; get; }
        public DateTime DateOfBirth { set; get; }

        public string ImagePath { set; get; }

        public int NationalityCountryID { set; get; }

        public clsPeopleBusinessLayer()

        {
            this.ID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.NationalNo = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;

        }

        private clsPeopleBusinessLayer(int ID, string FirstName, string SecondName, string ThirdName, string LastName,
     string Email, string Phone, string NationalNo, string Address, DateTime DateOfBirth, int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.ID = PeopleDataAccess.AddNewPerosn(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Phone,
                this.NationalNo, this.Address, this.DateOfBirth, this.NationalityCountryID, this.ImagePath);

            return (this.ID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return PeopleDataAccess.UpdatePerson(this.ID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Phone,
                this.NationalNo, this.Address, this.DateOfBirth, this.NationalityCountryID, this.ImagePath);

        }
        public static DataTable GetAllCountries()
        {
            return PeopleDataAccess.GetAllCountries();

        }
        public static DataTable GetAllPeople()
        {
            return PeopleDataAccess.GetAllPeople();

        }

        public static clsPeopleBusinessLayer Find(int ID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", NationalNo = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;

            if (PeopleDataAccess.GetPersonInfoByID(ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                        ref Email, ref Phone, ref NationalNo, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))

                return new clsPeopleBusinessLayer(ID, FirstName, SecondName, ThirdName, LastName,
                    Email, Phone, NationalNo, Address, DateOfBirth, CountryID, ImagePath);
            else
                return null;
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                //case enMode.Update:

                //    return _UpdatePerson();

            }
            return false;

        }
    }
}
