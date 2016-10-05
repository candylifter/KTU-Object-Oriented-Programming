namespace Lab2.Step1
{
    class Branch
    {
        public const int MaxNumberOfDogs = 50;

        public string Town { get; set; }
        public DogsContainer Dogs { get; private set; }
        
        public Branch(string town)
        {
            Town = town;
            Dogs  = new DogsContainer(MaxNumberOfDogs);
        }
    }
}
