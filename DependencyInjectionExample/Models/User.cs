namespace DependencyInjectionExample.Models
{
    /*
     * The field names are set in such a way that the ReadFromJsonAsync() function works correctly. 
     * Because when receiving JSON, such field names are defined in it.
     * 
     * Important! Not all fields that are returned to JSON are listed here, but only those necessary to demonstrate the capabilities.
     */

    /*
     * It is assumed that the data in MongoDB and the data in publicAPI have the same model (the same fields). 
     * Accordingly, to replace MongoDB with publicAPI, we just need to replace the service
     */
    public class User
    {
        public int id { get; set; }
        public Guid uid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public UserAddress address { get; set; }
    }
}
