﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Domain.ContactModels
{
    public class ContactExpandedModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }

        public string CountryName { get; set; }

        public int CompanyId { get; set; }

        public int CountryId { get; set; }
    }
}
