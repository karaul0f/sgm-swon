using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Client.Scripts.Services.Interfaces;

namespace Assets.Client.Scripts.Services.Implementations.ClientGenerator
{
    public class OrderedClientGenerator: IClientGenerator
    {
        public event EventHandler<Person> ClientChange;

        private readonly ILoader<Person> _clientLoader;
        private IEnumerable<Person> _allClients;


        public OrderedClientGenerator(ILoader<Person> clientLoader)
        {
            _clientLoader = clientLoader;

            InitializeClients();
        }

        public Person CurrentClient { get; private set; }

        public void ChangeClient()
        {
            var clientList = _allClients as IList<Person>;
            var currentIndex = clientList?.IndexOf(CurrentClient);

            if (!CanGoNext(currentIndex, clientList?.Count))
            {
                InitializeClients();
                return;
            }

            GoNext(currentIndex, clientList);
        }

        private void InitializeClients()
        {
            _allClients = _clientLoader.Load();

            var firstClient = _allClients.FirstOrDefault();
            UpdateClient(firstClient);
        }

        private void UpdateClient(Person client)
        {
            CurrentClient = client;
            ClientChange?.Invoke(this, CurrentClient);
        }

        private static bool CanGoNext(int? index, int? length)
        {
            var isLengthCorrect = length != null;
            var isIndexCorrect = index != null && index != -1 && index != length - 1;

            return isLengthCorrect && isIndexCorrect;
        }

        private void GoNext(int? currentIndex, IList<Person> clientList)
        {
            if (currentIndex == null)
                return;

            var nextClient = clientList[(int)currentIndex + 1];

            UpdateClient(nextClient);
        }
    }
}
