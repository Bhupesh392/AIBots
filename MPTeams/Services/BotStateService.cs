using Microsoft.Bot.Builder;
using MPTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPTeams.Services
{
    public class BotStateService
    {
        #region Variables
        //state variables
        public ConversationState ConversationState { get; }
        public UserState UserState { get; }

        //Ids
        public static string UserProfileId { get; } = $"{nameof(BotStateService)}.UserProfile";
        public static string ConverstationDataId { get; } = $"{nameof(BotStateService)}.ConversationData";

        //Accessors 
        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }
        public IStatePropertyAccessor<ConverstationData> ConversationDataAccessor { get; set; }
        #endregion

        public BotStateService(ConversationState conversationState, UserState userState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(ConversationState));
            UserState = userState ?? throw new ArgumentNullException(nameof(userState));

            InitializeAccessors();
        }

        private void InitializeAccessors()
        {
            // Initialize Conversation State Accessor 
            ConversationDataAccessor = ConversationState.CreateProperty<ConverstationData>(ConverstationDataId);

            //Initialize User State 
            UserProfileAccessor = UserState.CreateProperty<UserProfile>(UserProfileId);
        }
    }
}
