﻿namespace WalletAPI.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Wallet? PersonalWallet { get; set; }


    }
}
