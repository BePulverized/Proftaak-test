namespace ICT4Rails.Models
{
    public class GenericKeyValueModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}