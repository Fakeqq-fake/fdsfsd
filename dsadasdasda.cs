using System;

public interface IPaymentMethod
{
    void ProcessPayment(decimal amount);
    string GetPaymentType();
}

public class CreditCardPayment : IPaymentMethod
{
    private string cardNumber;
    private string cardHolderName;

    public CreditCardPayment(string cardNumber, string cardHolderName)
    {
        this.cardNumber = cardNumber;
        this.cardHolderName = cardHolderName;
    }

    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Обработка платежа картой: {cardNumber}");
        Console.WriteLine($"Владелец карты: {cardHolderName}");
        Console.WriteLine($"Сумма: ${amount:F2}");
        Console.WriteLine("Платёж успешно обработан!");
        Console.WriteLine("---");
    }

    public string GetPaymentType()
    {
        return "Банковская карта";
    }
}

public class PayPalPayment : IPaymentMethod
{
    private string email;

    public PayPalPayment(string email)
    {
        this.email = email;
    }

    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Обработка платежа через PayPal: {email}");
        Console.WriteLine($"Сумма: ${amount:F2}");
        Console.WriteLine("Платёж через PayPal успешно обработан!");
        Console.WriteLine("---");
    }

    public string GetPaymentType()
    {
        return "PayPal";
    }
}

public class CryptoPayment : IPaymentMethod
{
    private string walletAddress;
    private string cryptoType;

    public CryptoPayment(string walletAddress, string cryptoType)
    {
        this.walletAddress = walletAddress;
        this.cryptoType = cryptoType;
    }

    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Обработка криптоплатежа: {cryptoType}");
        Console.WriteLine($"Кошелёк: {walletAddress}");
        Console.WriteLine($"Сумма: {amount} {cryptoType}");
        Console.WriteLine("Криптоплатёж успешно обработан!");
        Console.WriteLine("---");
    }

    public string GetPaymentType()
    {
        return "Криптовалюта";
    }
}

public class PaymentProcessor
{
    public void MakePayment(IPaymentMethod paymentMethod, decimal amount)
    {
        Console.WriteLine($"Начало обработки платежа через: {paymentMethod.GetPaymentType()}");
        paymentMethod.ProcessPayment(amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IPaymentMethod creditCard = new CreditCardPayment("1234-5678-9012-3456", "Иван Иванов");
        IPaymentMethod paypal = new PayPalPayment("ivan@example.com");
        IPaymentMethod crypto = new CryptoPayment("0x123abc...", "Bitcoin");

        PaymentProcessor processor = new PaymentProcessor();

        Console.WriteLine("=== ДЕМОНСТРАЦИЯ ПОЛИМОРФИЗМА ===");
        Console.WriteLine();

        processor.MakePayment(creditCard, 100.50m);
        processor.MakePayment(paypal, 75.25m);
        processor.MakePayment(crypto, 0.005m);
        Console.WriteLine("=== ПОЛИМОРФИЗМ ЧЕРЕЗ МАССИВ ===");
        Console.WriteLine();

        IPaymentMethod[] payments = { creditCard, paypal, crypto };
        decimal[] amounts = { 50.00m, 30.75m, 0.01m };

        for (int i = 0; i < payments.Length; i++)
        {
            processor.MakePayment(payments[i], amounts[i]);
        }

        Console.WriteLine("Все платежи успешно обработаны!");
    }
}
