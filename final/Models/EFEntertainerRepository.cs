namespace final.Models
{ //SETTING THE REPOSITORIES YEAH
    public class EFEntertainerRepository : IEntertainerRepository
    {
        private EntertainmentAgencyExampleContext _context;

        public EFEntertainerRepository(EntertainmentAgencyExampleContext temp)
        {
            _context = temp;
        }

        public List<Entertainer> Entertainers => _context.Entertainers.ToList();

        public void AddEntertainer(Entertainer entertainer)
        {
            _context.Add(entertainer);
            _context.SaveChanges();
        }
        public void UpdateEntertainer(Entertainer entertainer)
        {
            _context.Update(entertainer);
            _context.SaveChanges();

        }

        public void DeleteEntertainer(Entertainer entertainer) 
        {
            _context.Remove(entertainer);
            _context.SaveChanges();
        }
    }
}
