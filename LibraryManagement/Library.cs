using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
    public class Library
    {
        public const string LibraryName = "City Library"; //Compile time constant
        public readonly DateTime CreatedDate; // RunTime Constant

        public Library() : this(DateTime.Now) { }

        public Library(DateTime createdDate)
        {
            {
                this.CreatedDate = createdDate;
            }
        }
    }
}