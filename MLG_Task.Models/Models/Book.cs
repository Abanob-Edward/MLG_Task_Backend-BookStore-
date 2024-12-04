using MLG_Task.Models.Models;

namespace MLG_Task.Model
{
    public class Book :BaseEntity
    {
       
        public string Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int  PublishedYear {  get; set; }
    }
}
