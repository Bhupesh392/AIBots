using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPTeams.Models
{
    public class ConverstationData
    {
        // Track whether we have already asked the user's name
        public bool PromptedUserForName { get; set; } = false;
    }
}
