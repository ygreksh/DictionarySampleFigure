namespace DictionarySampleFigure
{
    public class Figure
    {
        public int SideCount { get; set; }
        public int SideLenght { get; set; }
        
        public bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Figure)) return false;
            Figure newFigure = (Figure) obj;
            return SideCount == newFigure.SideCount && SideLenght == newFigure.SideLenght;
        }

        public override int GetHashCode()
        {
            return SideCount.GetHashCode()*1000 + SideLenght.GetHashCode();
        }

        public override string ToString()
        {
            return "(" + SideCount + ", " + SideLenght + ")";
        }
    }
    
    
}