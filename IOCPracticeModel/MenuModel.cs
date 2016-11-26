using System;

namespace IOCPracticeModel
    {
    public class MenuModel
        {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string SourcePath { get; set; }

        public int State { get; set; }

        public int MenuLevel { get; set; }

        public int Sort { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreatorId { get; set; }

        public int? LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }
        }
    }