namespace final.Models
{ //INTERFACE REPOSITORY
    public interface IEntertainerRepository
    {
        List<Entertainer> Entertainers { get; }

        public void AddEntertainer(Entertainer entertainer);
        public void UpdateEntertainer(Entertainer entertainer);
        public void DeleteEntertainer(Entertainer entertainer);
        
    }
}
