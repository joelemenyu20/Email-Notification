using AssignmentCL.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    public partial class Service1 : ServiceBase
    {
        private Thread sendEmail;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            sendEmail = new Thread(new ThreadStart(SendEmailNotification));
            sendEmail.Start();
        }

        private void SendEmailNotification()
        {
            Logic email = new Logic();
            email.SendEmailNotification();
        }

        protected override void OnStop()
        {
            sendEmail.Abort();
        }
    }
}
