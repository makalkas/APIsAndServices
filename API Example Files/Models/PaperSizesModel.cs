namespace AmetekLabelAPI.Models
{
    /// <summary>
    /// Contains basic information on paper sizes
    /// </summary>
    public class PaperSizesModel
    {
        private List<PaperSizeModel>? _paperSizes;

        /// <summary>
        /// This holds a list of most used paper sizes.
        /// </summary>
        public PaperSizesModel()
        {
            GeneratePaperSizes();
        }

        /// <summary>
        /// This holds a list of most used paper sizes.
        /// </summary>
        public PaperSizesModel(string Size)
        {
            GeneratePaperSizes();

            PaperSizeModel size = CommonPaperSizes!.Where(x => x.Name == Size).FirstOrDefault()!;
            this.Name = Size;
            if (size != null)
            {
                this.WidthInInches = size.WidthInches;
                this.HeightInInches = size.HeightInches;
                this.WidthInPoints = size.WidthPoints;
                this.HeightInPoints = size.HeightPoints;
            }
        }

        /// <summary>
        /// List of most common ISO paper sizes.
        /// </summary>
        public List<PaperSizeModel>? CommonPaperSizes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; } = "Not Set";

        /// <summary>
        /// 
        /// </summary>
        public double WidthInInches { get; private set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public double HeightInInches { get; private set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public int WidthInPoints { get; private set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public int HeightInPoints { get; private set; } = 0;

        private void GeneratePaperSizes()
        {
            _paperSizes = new List<PaperSizeModel>()
            {
                new PaperSizeModel("A0",33.11,46.81,2384,3370),
                new PaperSizeModel("A1",23.39,33.11,1684,2384),
                new PaperSizeModel("A2",16.54,23.39,1190,1684),
                new PaperSizeModel("A3",11.69,16.54,842,1190),
                new PaperSizeModel("A4",8.27,11.69,595,842),
                new PaperSizeModel("A5",5.83,8.27,420,595),
                new PaperSizeModel("A6",4.13,5.83,298,420),
                new PaperSizeModel("A7",2.91,4.13,210,298),
                new PaperSizeModel("A8",2.05,2.91,148,210),
                new PaperSizeModel("Letter",8.5,11.0,612,792),
                new PaperSizeModel("Legal",8.5,14.0,612,1008),
                new PaperSizeModel("Ledger",11.0,17.0,792,1224),
                new PaperSizeModel("Tabloid",17.0,11,1224,792),
                new PaperSizeModel("Executive",7.25,10.55,522,756),
                new PaperSizeModel("ANSI C",22.0,17.0,1584,1224),
                new PaperSizeModel("ANSI D",34.0,22.0,2448,1584),
                new PaperSizeModel("ANSI E",44.0,34.0,3168,2448),
                new PaperSizeModel("B0",39.37,55.67,2835,4008),
                new PaperSizeModel("B1",27.83,39.37,2004,2835),
                new PaperSizeModel("B2",19.69,27.83,1417,2004),
                new PaperSizeModel("B3",13.90,19.69,1001,1417),
                new PaperSizeModel("B4",9.84,13.90,709,1001),
                new PaperSizeModel("B5",6.93,9.84,499,709),
                new PaperSizeModel("B6",4.92,6.93,354,499),
                new PaperSizeModel("B7",3.46,4.92,249,354),
                new PaperSizeModel("B8",2.44,3.46,176,249),
                new PaperSizeModel("B9",1.73,2.44,125,176),
                new PaperSizeModel("B10",1.22,1.73,88,125),
                new PaperSizeModel("C2",25.51,18.03,1837,1298),
                new PaperSizeModel("C3",18.03,12.76,1298,919),
                new PaperSizeModel("C4",12.76,9.02,919,649),
                new PaperSizeModel("C5",9.02,6.38,649,459),
                new PaperSizeModel("C6",6.38,4.49,459,323)
            };

            this.CommonPaperSizes = _paperSizes;
        }
    }
}
