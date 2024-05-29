using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Models
{
    public class Wallet
    {

        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Your balance cannot be less than zero.")]
        decimal Balance { get; set; } = 0;

    }
}
