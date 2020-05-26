// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MPTeams.Bots;
using MPTeams.Services;

namespace MPTeams
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Create the Bot Framework Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

            //Configure State
            ConfigureState(services);

            // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.AddTransient<IBot, GreetingBot>();
        }

        public void ConfigureState(IServiceCollection services)
        {
            //Create the Storage we'll be using for User and Converstation state. (Memory is great for testing purpose.)
            services.AddSingleton<IStorage, MemoryStorage>();

            //var storageAccount = "DefaultEndpointsProtocol=https;AccountName=mpbotdemo;AccountKey=6r7OFWodMzxb8ylDL2AtU4kXtp/3K/1eVEpDQpNRyvJ4kjy7+8P7lIfUJQRHghvdy7nDO3xJ2OnQrepaCkYcnA==;EndpointSuffix=core.windows.net";
            //var storageContainer = "mpbotdemo";

            //services.AddSingleton<IStorage>(new AzureBlobStorage(storageAccount, storageContainer));

            //Create the user state.
            services.AddSingleton<UserState>();

            //Create the Conversation state.
            services.AddSingleton<ConversationState>();

            //Create an instance of the state service
            services.AddSingleton<BotStateService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
