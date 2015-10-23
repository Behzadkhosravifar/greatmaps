using System.Drawing.Printing;

namespace GMap.NET.ObjectModel
{
    public static class PaperSizes
    {
        public static PaperSize A3
        {
            get
            {
                return new PaperSize("A3", 1170, 1650) { RawKind = (int)PaperKind.Custom };
            }
        }

        public static PaperSize A4
        {
            get { return new PaperSize("A4", 830, 1170) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize A5
        {
            get { return new PaperSize("A5", 580, 830) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize A6
        {
            get { return new PaperSize("A6", 410, 580) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize A7
        {
            get { return new PaperSize("A7", 290, 410) { RawKind = (int)PaperKind.Custom }; }
        }

        //public static PaperSize A8
        //{
        //    get { return new PaperSize("A8", 200, 290) { RawKind = (int)PaperKind.Custom }; }
        //}

        //public static PaperSize A9
        //{
        //    get { return new PaperSize("A9", 150, 200) { RawKind = (int)PaperKind.Custom }; }
        //}

        public static PaperSize B3
        {
            get { return new PaperSize("B3", 1390, 1970) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize B4
        {
            get { return new PaperSize("B4", 980, 1390) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize B5
        {
            get { return new PaperSize("B5", 690, 980) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize B6
        {
            get { return new PaperSize("B6", 490, 690) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize B7
        {
            get { return new PaperSize("B7", 350, 490) { RawKind = (int)PaperKind.Custom }; }
        }

        //public static PaperSize B8
        //{
        //    get { return new PaperSize("B8", 240, 350) { RawKind = (int)PaperKind.Custom }; }
        //}

        //public static PaperSize B9
        //{
        //    get { return new PaperSize("B9", 170, 240) { RawKind = (int)PaperKind.Custom }; }
        //}

        public static PaperSize C3
        {
            get { return new PaperSize("C3", 1280, 1800) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize C4
        {
            get { return new PaperSize("C4", 900, 1280) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize C5
        {
            get { return new PaperSize("C5", 640, 900) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize C6
        {
            get { return new PaperSize("C6", 450, 640) { RawKind = (int)PaperKind.Custom }; }
        }

        public static PaperSize C7
        {
            get { return new PaperSize("C7", 320, 450) { RawKind = (int)PaperKind.Custom }; }
        }

        //public static PaperSize C8
        //{
        //    get { return new PaperSize("C8", 220, 320) { RawKind = (int)PaperKind.Custom }; }
        //}

        //public static PaperSize C9
        //{
        //    get { return new PaperSize("C9", 160, 220) { RawKind = (int)PaperKind.Custom }; }
        //}

        public static PaperSize DL
        {
            get { return new PaperSize("C10", 430, 860) { RawKind = (int)PaperKind.Custom }; }
        }


        public static PaperSize GetPaperSize(string kind)
        {
            foreach (var prop in typeof(PaperSizes).GetProperties())
            {
                if (prop.Name == kind.ToUpper())
                {
                    return (PaperSize)prop.GetValue(null);
                }
            }

            return null;
        }

    }
}
