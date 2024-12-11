namespace AmetekLabelAPI.Models
{
    /// <summary>
    /// Contains data for one specific paper size.
    /// </summary>
    public class PaperSizeModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PaperSizeModel() { }

        /// <summary>
        /// Constructor with main parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="widthInches"></param>
        /// <param name="heightInches"></param>
        /// <param name="widthPoints"></param>
        /// <param name="heightPoints"></param>
        public PaperSizeModel(string name, double widthInches, double heightInches, int widthPoints, int heightPoints)
        {
            Name = name;
            WidthInches = widthInches;
            HeightInches = heightInches;
            WidthPoints = widthPoints;
            HeightPoints = heightPoints;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public double WidthInches { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double HeightInches { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int WidthPoints { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int HeightPoints { get; set; }
    }
}
