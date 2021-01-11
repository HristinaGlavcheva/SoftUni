using System.Collections.Generic;
using System.Xml.Serialization;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDTO
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")] 
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public List<ExportTaskDTO> Tasks { get; set; }
    }

    [XmlType("Task")]
    public class ExportTaskDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }
}

  //<Project TasksCount = "10" >
  //  < ProjectName > Hyster - Yale </ ProjectName >
  //  < HasEndDate > No </ HasEndDate >
  //  < Tasks >
  //    < Task >
  //      < Name > Broadleaf </ Name >
  //      < Label > JavaAdvanced </ Label >
  //    </ Task >
  //    < Task >
  //      < Name > Bryum </ Name >
  //      < Label > EntityFramework </ Label >
  //    </ Task >
  //    < Task >
  //      < Name > Cornflag </ Name >
  //      < Label > CSharpAdvanced </ Label >
  //    </ Task >
  //    < Task >
  //      < Name > Crandall </ Name >
  //      < Label > Priority </ Label >
  //    </ Task >
  //    < Task >
  //      < Name > Debeque </ Name >
  //      < Label > JavaAdvanced </ Label >
  //    </ Task >
  //    < Task >
  //      < Name > Guadalupe </ Name >
  //      < Label > JavaAdvanced </ Label >
  //    </ Task >
  //    < Task >
  //      < Name > Guadeloupe </ Name >
  //      < Label > JavaAdvanced </ Label >
  //    </ Task >
  //    < Task >
  //      < Name > Longbract Pohlia Moss</Name>
  //         <Label>EntityFramework</Label>
  //       </Task>
  //    <Task>
  //      <Name>Meyen's Sedge</Name>
  //      <Label>EntityFramework</Label>
  //       </Task>
  //    <Task>
  //      <Name>Pacific</Name>
  //         <Label>Priority</Label>
  //       </Task>
  //  </Tasks>
  //</Project>
