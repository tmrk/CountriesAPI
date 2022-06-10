namespace CountriesAPI
{
    public class Country
    {
        public string? name { get; set; }
        public string? nameFrench { get; set; }
        public string? nameSpanish { get; set; }
        public string? nameRussian { get; set; }
        public string? nameChinese { get; set; }
        public string? nameArabic { get; set; }
        public string? alpha2 { get; set; }
        public string? alpha3 { get; set; }
        public string? m49code { get; set; }
        public string? region { get; set; }
        public string? subRegion { get; set; }
        public string? intermediateRegion { get; set; }
        public bool? LDC { get; set; }
        public bool? LLDC { get; set; }

        public Country(string? Name, string? NameFrench, string? NameSpanish, string? NameRussian, string? NameChinese, string? NameArabic,
                       string? Alpha2, string? Alpha3, string? M49code, string? Region, string? SubRegion, string? IntermediateRegion, bool? Ldc, bool? Lldc)
        {
            if (!String.IsNullOrEmpty(Name)) name = Name;
            if (!String.IsNullOrEmpty(NameFrench)) nameFrench = NameFrench;
            if (!String.IsNullOrEmpty(NameSpanish)) nameSpanish = NameSpanish;
            if (!String.IsNullOrEmpty(NameRussian)) nameRussian = NameRussian;
            if (!String.IsNullOrEmpty(NameChinese)) nameChinese = NameChinese;
            if (!String.IsNullOrEmpty(NameArabic)) nameArabic = NameArabic;
            if (!String.IsNullOrEmpty(Alpha2)) alpha2 = Alpha2;
            if (!String.IsNullOrEmpty(Alpha3)) alpha3 = Alpha3;
            if (!String.IsNullOrEmpty(M49code)) m49code = M49code;
            if (!String.IsNullOrEmpty(Region)) region = Region;
            if (!String.IsNullOrEmpty(SubRegion)) subRegion = SubRegion;
            if (!String.IsNullOrEmpty(IntermediateRegion)) intermediateRegion = IntermediateRegion;
            if (Ldc.HasValue) LDC = Ldc;
            if (Lldc.HasValue) LLDC = Lldc;
        }


        public Country() { }
    }
}
