using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.Models
{
    interface INameId
    {

         string ID {get; set; }

        

         string Name{get;set;}

         void Add(string name);
         void Edit(INameId temp);
       

       
    }
}

