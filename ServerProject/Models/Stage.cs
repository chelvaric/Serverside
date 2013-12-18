﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerProject.Models
{
    public class Stage:INameId
    {

        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
             
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                
            }
        }
    }
}