using System;
using System.ComponentModel.DataAnnotations;

namespace Teht2
{
    public class NewItem
    {
        public string Name { get; set; }

        [Range(1, 99)]
        public int Level {get; set;}

        [ItemTypeLegless]
        public string Type {get; set;}

        [DateTypeLegless]
        [DataType(DataType.Date)]
        public DateTime CreationDate {get; set;}
        }
    }