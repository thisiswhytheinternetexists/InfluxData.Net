﻿using System;
using InfluxData.Net.Common.Enums;
using InfluxData.Net.Kapacitor.ClientModules;
using InfluxData.Net.Kapacitor.Infrastructure;
using InfluxData.Net.Kapacitor.RequestClients;

namespace InfluxData.Net.Kapacitor
{
    public class KapacitorClient : IKapacitorClient
    {
        private readonly IKapacitorRequestClient _requestClient;

        private readonly Lazy<ITaskClientModule> _taskClientModule;
        public ITaskClientModule Task
        {
            get { return _taskClientModule.Value; }
        }

        public KapacitorClient(string uri, KapacitorVersion kapacitorVersion)
            : this(new KapacitorClientConfiguration(new Uri(uri), null, null, kapacitorVersion))
        {
        }


        //public KapacitorClient(string uri, string username, string password, KapacitorVersion kapacitorVersion)
        //     : this(new KapacitorClientConfiguration(new Uri(uri), username, password, kapacitorVersion))
        //{
        //}

        public KapacitorClient(KapacitorClientConfiguration configuration)
        {
            var requestClientFactory = new RequestClientFactory(configuration);
            _requestClient = requestClientFactory.GetRequestClient();

            _taskClientModule = new Lazy<ITaskClientModule>(() => new TaskClientModule(_requestClient));
        }
    }
}