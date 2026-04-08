namespace MedTenant.Application.Entities
{
    public class Speciality
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Speciality(string name)
        {
            Name = name;
        }
    }
}