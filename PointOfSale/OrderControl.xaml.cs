using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CowboyCafe.Data;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            InitializeComponent();
            AngryChickenButton.Click += OnAngryChickenButtonClicked;
            BakedBeansButton.Click += OnBakedBeansButtonClicked;
            ChiliCheeseFriesButton.Click += OnChiliCheeseFriesButtonClicked;
            CornDodgersButton.Click += OnCornDodgersButtonClicked;
            CowboyCoffeeButton.Click += OnCowboyCoffeeButtonClicked;
            CowpokeChiliButton.Click += OnCowpokeChiliButtonClicked;
            DakotaDoubleBurgerButton.Click += OnDakotaDoubleBurgerButtonClicked;
            JerkedSodaButton.Click += OnJerkedSodaButtonClicked;
            PanDeCampoButton.Click += OnPanDeCampoButtonClicked;
            PecosPulledPorkButton.Click += OnPecosPulledPorkButtonClicked;
            RustlersRibsButton.Click += OnRustlersRibsButtonClicked;
            TexasTeaButton.Click += OnTexasTeaButtonClicked;
            TexasTripleBurgerButton.Click += OnTexasTripleBurgerButtonClicked;
            TrailBurgerButton.Click += OnTrailBurgerButtonClicked;
            WaterButton.Click += OnWaterButtonClicked;
        }

        void OnAngryChickenButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new AngryChicken());
        }

        void OnBakedBeansButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new BakedBeans());
        }

        void OnChiliCheeseFriesButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new ChiliCheeseFries());
        }

        void OnCornDodgersButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new CornDodgers());
        }

        void OnCowboyCoffeeButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new CowboyCoffee());
        }

        void OnCowpokeChiliButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new CowpokeChili());
        }

        void OnDakotaDoubleBurgerButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new DakotaDoubleBurger());
        }

        void OnJerkedSodaButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new JerkedSoda());
        }

        void OnPanDeCampoButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new PanDeCampo());
        }

        void OnPecosPulledPorkButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new PecosPulledPork());
        }

        void OnRustlersRibsButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new RustlersRibs());
        }

        void OnTexasTeaButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new TexasTea());
        }

        void OnTexasTripleBurgerButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new TexasTripleBurger());
        }

        void OnTrailBurgerButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new TrailBurger());
        }

        void OnWaterButtonClicked(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new Water());
        }
    }
}