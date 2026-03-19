namespace Library.Root.Object
{
    public class UserProfile
    {
        private string _COMPANY;
        private string _ORGANIZATION;
        private string _USER_ID;
        private string _USR_NAME;
        private string _EMP_NAME;
        private string _USR_EMAIL;
        private System.DateTime _DATE_JOIN;

        public UserProfile(string company, string organization, string user_id, string usr_name, string emp_name, string usr_email, System.DateTime date_join)
        {
            _COMPANY = company;
            _ORGANIZATION = organization;
            _USER_ID = user_id;
            _USR_NAME = usr_name;
            _EMP_NAME = emp_name;
            _USR_EMAIL = usr_email;
            _DATE_JOIN = date_join;
        }

        public string Company
        {
            get { return _COMPANY; }
        }

        public string Organization
        {
            get { return _ORGANIZATION; }
        }

        public string UserID
        {
            get { return _USER_ID; }
        }

        public string Username
        {
            get { return _USR_NAME; }
        }

        public string Name
        {
            get { return _EMP_NAME; }
        }

        public string Email
        {
            get { return _USR_EMAIL; }
        }

        public System.DateTime DateJoin
        {
            get { return _DATE_JOIN; }
        }
    }
}
