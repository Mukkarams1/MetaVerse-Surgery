using System.Collections.Generic;

public class PatientData
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Disease { get; set; }
    public string Detials { get; set; }
}

public class PatientList
{
    public List<PatientData> PatientData { get; set; }
}
