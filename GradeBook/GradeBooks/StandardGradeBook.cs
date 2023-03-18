using GradeBook.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook:BaseGradeBook
    {
        
        GradeBookType Type = GradeBookType.Standard;
        public StandardGradeBook(string name) : base(name)
        {

            Type = GradeBookType.Standard;
        }
        public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Standard;
        }

    }
   

        
        





}
