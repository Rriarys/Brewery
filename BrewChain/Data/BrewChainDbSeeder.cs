using BrewChain.Models;
namespace BrewChain.Data;

public class BrewChainDbSeeder
{
    public static void Seed(BrewChainDbContext dbContext)
    {
        if (dbContext.Breweries.Any()) return; // Database has already been seeded

        // ================ Create some breweries ================
        var abbate = new Brewery { Name = "Abbaye de Leffe", Country = "BE", Wallet = new Wallet { Balance = 1000m } }; // LockedBalance is defaults to 0
        var chimay = new Brewery { Name = "Brasserie de Chimay", Country = "BE", Wallet = new Wallet { Balance = 1000m } };
        var guinness = new Brewery { Name = "Guinness Storehouse", Country = "IE", Wallet = new Wallet { Balance = 1000m } };
        var heineken = new Brewery { Name = "Heineken Brouwerijen", Country = "NL", Wallet = new Wallet { Balance = 1000m } };
        var carlsberg = new Brewery { Name = "Carlsberg Brewery", Country = "DK", Wallet = new Wallet { Balance = 1000m } };
        var kronenbourg = new Brewery { Name = "Kronenbourg Brewery", Country = "FR", Wallet = new Wallet { Balance = 1000m } };
        var moretti = new Brewery { Name = "Birra Moretti", Country = "IT", Wallet = new Wallet { Balance = 1000m } };
        var modelo = new Brewery { Name = "Grupo Modelo", Country = "MX", Wallet = new Wallet { Balance = 1000m } };
        var asahi = new Brewery { Name = "Asahi Breweries", Country = "JP", Wallet = new Wallet { Balance = 1000m } };

        // ================ Create some beers for each brewery ================
        var leffeBlonde = new Beer
        {
            Name = "Leffe Blonde",
            AlcoholContent = 6.6m,
            Price = 2.5m,
            Brewery = abbate
        };
        var leffeBrune = new Beer
        {
            Name = "Leffe Brune",
            AlcoholContent = 6.5m,
            Price = 2.8m,
            Brewery = abbate
        };
        var chimayRed = new Beer
        {
            Name = "Chimay Rouge",
            AlcoholContent = 7.0m,
            Price = 3.0m,
            Brewery = chimay
        };
        var chimayBlue = new Beer
        {
            Name = "Chimay Bleue",
            AlcoholContent = 9.0m,
            Price = 3.5m,
            Brewery = chimay
        };
        var chimayTriple = new Beer
        {
            Name = "Chimay Triple",
            AlcoholContent = 8.0m,
            Price = 3.2m,
            Brewery = chimay
        };
        var guinnessExtra = new Beer
        {
            Name = "Guinness Extra Stout",
            AlcoholContent = 7.2m,
            Price = 3.2m,
            Brewery = guinness
        };
        var heinekeenLager = new Beer
        {
            Name = "Heineken Lager",
            AlcoholContent = 5.0m,
            Price = 2.0m,
            Brewery = heineken
        };
        var carlsbergPilsner = new Beer
        {
            Name = "Carlsberg Pilsner",
            AlcoholContent = 4.6m,
            Price = 1.8m,
            Brewery = carlsberg
        };
        var kronenbourg1664 = new Beer
        {
            Name = "Kronenbourg 1664",
            AlcoholContent = 5.2m,
            Price = 2.2m,
            Brewery = kronenbourg
        };
        var moretiLager = new Beer
        {
            Name = "Moretti Lager",
            AlcoholContent = 4.6m,
            Price = 2.1m,
            Brewery = moretti
        };
        var modeloEspecial = new Beer
        {
            Name = "Modelo Especial",
            AlcoholContent = 4.4m,
            Price = 2.3m,
            Brewery = modelo
        };
        var asahiSuperdry = new Beer
        {
            Name = "Asahi Super Dry",
            AlcoholContent = 5.0m,
            Price = 2.4m,
            Brewery = asahi
        };
        var leffeRadieuse = new Beer
        {
            Name = "Leffe Radieuse",
            AlcoholContent = 8.2m,
            Price = 3.0m,
            Brewery = abbate
        };
        var chimayWhite = new Beer
        {
            Name = "Chimay Cinq Cents",
            AlcoholContent = 10.0m,
            Price = 3.8m,
            Brewery = chimay
        };
        var guinnessStout = new Beer
        {
            Name = "Guinness Draught",
            AlcoholContent = 4.3m,
            Price = 2.8m,
            Brewery = guinness
        };
        var heinekenDark = new Beer
        {
            Name = "Heineken Dark",
            AlcoholContent = 5.3m,
            Price = 2.3m,
            Brewery = heineken
        };
        var carlsbergExport = new Beer
        {
            Name = "Carlsberg Export",
            AlcoholContent = 5.0m,
            Price = 2.0m,
            Brewery = carlsberg
        };
        var kronenbourBlanc = new Beer
        {
            Name = "Kronenbourg Blanc",
            AlcoholContent = 5.0m,
            Price = 2.4m,
            Brewery = kronenbourg
        };
        var moretiAmber = new Beer
        {
            Name = "Moretti Ambra",
            AlcoholContent = 5.0m,
            Price = 2.2m,
            Brewery = moretti
        };
        var modeloNegra = new Beer
        {
            Name = "Modelo Negra",
            AlcoholContent = 5.1m,
            Price = 2.5m,
            Brewery = modelo
        };
        var asahiGinger = new Beer
        {
            Name = "Asahi Ginger",
            AlcoholContent = 4.5m,
            Price = 2.6m,
            Brewery = asahi
        };

        // ================ Create some stock entries for the breweries ================
        var breweryStock1 = new BreweryStock{
            Brewery = abbate,
            Beer = leffeBlonde,
            Quantity = 200
        };
        var breweryStock2 = new BreweryStock{
            Brewery = abbate,
            Beer = leffeBrune,
            Quantity = 150
        };
        var breweryStock3 = new BreweryStock{
            Brewery = chimay,
            Beer = chimayRed,
            Quantity = 120
        };
        var breweryStock4 = new BreweryStock{
            Brewery = chimay,
            Beer = chimayBlue,
            Quantity = 100
        };
        var breweryStock5 = new BreweryStock{
            Brewery = chimay,
            Beer = chimayTriple,
            Quantity = 90
        };
        var breweryStock6 = new BreweryStock{
            Brewery = guinness,
            Beer = guinnessExtra,
            Quantity = 180
        };
        var breweryStock7 = new BreweryStock{
            Brewery = heineken,
            Beer = heinekeenLager,
            Quantity = 160
        };
        var breweryStock8 = new BreweryStock{
            Brewery = carlsberg,
            Beer = carlsbergPilsner,
            Quantity = 140
        };
        var breweryStock9 = new BreweryStock{
            Brewery = kronenbourg,
            Beer = kronenbourg1664,
            Quantity = 130
        };
        var breweryStock10 = new BreweryStock{
            Brewery = moretti,
            Beer = moretiLager,
            Quantity = 110
        };
        var breweryStock11 = new BreweryStock{
            Brewery = modelo,
            Beer = modeloEspecial,
            Quantity = 170
        };
        var breweryStock12 = new BreweryStock{
            Brewery = asahi,
            Beer = asahiSuperdry,
            Quantity = 150
        };

        // ================ Create some wholesalers ================
        var wholesaler1 = new Wholesaler { Name = "Brewery Supplies Co.", Country = "BE", Wallet = new Wallet { Balance = 5000m } };
        var wholesaler2 = new Wholesaler { Name = "Beer Distributors Inc.", Country = "BE", Wallet = new Wallet { Balance = 5000m } };
        var wholesaler3 = new Wholesaler { Name = "European Beer Traders", Country = "DE", Wallet = new Wallet { Balance = 5000m } };
        var wholesaler4 = new Wholesaler { Name = "Continental Beverages Ltd.", Country = "FR", Wallet = new Wallet { Balance = 5000m } };
        var wholesaler5 = new Wholesaler { Name = "Nordic Distribution Group", Country = "SE", Wallet = new Wallet { Balance = 5000m } };
        var wholesaler6 = new Wholesaler { Name = "Global Beer Importers", Country = "US", Wallet = new Wallet { Balance = 5000m } };
        var wholesaler7 = new Wholesaler { Name = "Craft Beer Connect", Country = "UK", Wallet = new Wallet { Balance = 5000m } };
        var wholesaler8 = new Wholesaler { Name = "Asian Beer Exporters", Country = "JP", Wallet = new Wallet { Balance = 5000m } };
        var wholesaler9 = new Wholesaler { Name = "Latin American Beer Distributors", Country = "MX", Wallet = new Wallet { Balance = 5000m } };

        // ================ Create some stock entries for the wholesalers ================
        var stock1 = new WholesalerStock{
            Wholesaler = wholesaler1,
            Beer = leffeBlonde,
            Quantity = 100
        };
        var stock2 = new WholesalerStock{
            Wholesaler = wholesaler1,
            Beer = chimayRed,
            Quantity = 50
        };
            var stock5 = new WholesalerStock{
            Wholesaler = wholesaler1,
            Beer = leffeBrune,
            Quantity = 80
        };
        var stock3 = new WholesalerStock{
            Wholesaler = wholesaler2,
            Beer = chimayBlue,
            Quantity = 75
        };
        var stock4 = new WholesalerStock{
            Wholesaler = wholesaler2,
            Beer = chimayTriple,
            Quantity = 60
        };
        var stock6 = new WholesalerStock{
            Wholesaler = wholesaler3,
            Beer = guinnessExtra,
            Quantity = 45
        };
        var stock7 = new WholesalerStock{
            Wholesaler = wholesaler4,
            Beer = heinekeenLager,
            Quantity = 90
        };
        var stock8 = new WholesalerStock{
            Wholesaler = wholesaler5,
            Beer = carlsbergPilsner,
            Quantity = 110
        };
        var stock9 = new WholesalerStock{
            Wholesaler = wholesaler6,
            Beer = kronenbourg1664,
            Quantity = 70
        };
        var stock10 = new WholesalerStock{
            Wholesaler = wholesaler7,
            Beer = moretiLager,
            Quantity = 55
        };
        var stock11 = new WholesalerStock{
            Wholesaler = wholesaler8,
            Beer = asahiSuperdry,
            Quantity = 95
        };
        var stock12 = new WholesalerStock{
            Wholesaler = wholesaler9,
            Beer = modeloEspecial,
            Quantity = 85
        };

        // ================ Create some shops ================
        var shop1 = new Shop { Name = "Downtown Beer Store", Country = "BE", Wallet = new Wallet { Balance = 5000m } };
        var shop2 = new Shop { Name = "Craft Beer Emporium", Country = "BE", Wallet = new Wallet { Balance = 5000m } };
        var shop3 = new Shop { Name = "The Beer Cellar", Country = "BE", Wallet = new Wallet { Balance = 5000m } };
        var shop4 = new Shop { Name = "Hoppy Haven", Country = "BE", Wallet = new Wallet { Balance = 5000m } };
        var shop5 = new Shop { Name = "Brew & Co.", Country = "BE", Wallet = new Wallet { Balance = 5000m } };
        var shop6 = new Shop { Name = "The Hoppy Hound", Country = "DE", Wallet = new Wallet { Balance = 5000m } };
        var shop7 = new Shop { Name = "Bière et Compagnie", Country = "FR", Wallet = new Wallet { Balance = 5000m } };
        var shop8 = new Shop { Name = "Birra Bella", Country = "IT", Wallet = new Wallet { Balance = 5000m } };
        var shop9 = new Shop { Name = "Cervecería Artesanal", Country = "ES", Wallet = new Wallet { Balance = 5000m } };
        var shop10 = new Shop { Name = "The Ale House", Country = "UK", Wallet = new Wallet { Balance = 5000m } };
        var shop11 = new Shop { Name = "Øl & Vin", Country = "DK", Wallet = new Wallet { Balance = 5000m } };
        var shop12 = new Shop { Name = "Brouwerij Winkel", Country = "NL", Wallet = new Wallet { Balance = 5000m } };
        var shop13 = new Shop { Name = "Cervejaria Local", Country = "PT", Wallet = new Wallet { Balance = 5000m } };
        var shop14 = new Shop { Name = "Pivovar Krčma", Country = "CZ", Wallet = new Wallet { Balance = 5000m } };

        // ================ Create some stock entries for the shops ================
        var shopStock1 = new ShopStock{
            Shop = shop1,
            Beer = leffeBlonde,
            Quantity = 20
        };
        var shopStock2 = new ShopStock{
            Shop = shop1,
            Beer = chimayRed,
            Quantity = 15
        };
        var shopStock3 = new ShopStock{
            Shop = shop2,
            Beer = chimayBlue,
            Quantity = 10
        };
        var shopStock4 = new ShopStock{     
            Shop = shop3,
            Beer = chimayTriple,
            Quantity = 5
        };
        var shopStock5 = new ShopStock{
            Shop = shop4,
            Beer = leffeBrune,
            Quantity = 25
        };
        var shopStock6 = new ShopStock{
            Shop = shop5,
            Beer = guinnessExtra,
            Quantity = 12
        };
        var shopStock7 = new ShopStock{
            Shop = shop6,
            Beer = heinekeenLager,
            Quantity = 18
        };
        var shopStock8 = new ShopStock{
            Shop = shop6,
            Beer = carlsbergPilsner,
            Quantity = 22
        };
        var shopStock9 = new ShopStock{
            Shop = shop6,
            Beer = kronenbourg1664,
            Quantity = 16
        };
        var shopStock10 = new ShopStock{
            Shop = shop7,
            Beer = moretiLager,
            Quantity = 14
        };
        var shopStock11 = new ShopStock{
            Shop = shop7,
            Beer = modeloEspecial,
            Quantity = 11
        };
        var shopStock12 = new ShopStock{
            Shop = shop7,
            Beer = asahiSuperdry,
            Quantity = 19
        };
        var shopStock13 = new ShopStock{
            Shop = shop7,
            Beer = leffeRadieuse,
            Quantity = 8
        };
        var shopStock14 = new ShopStock{
            Shop = shop8,
            Beer = chimayWhite,
            Quantity = 9
        };
        var shopStock15 = new ShopStock{
            Shop = shop8,
            Beer = guinnessStout,
            Quantity = 13
        };
        var shopStock16 = new ShopStock{
            Shop = shop8,
            Beer = heinekenDark,
            Quantity = 17
        };
        var shopStock17 = new ShopStock{
            Shop = shop9,
            Beer = carlsbergExport,
            Quantity = 21
        };
        var shopStock18 = new ShopStock{
            Shop = shop9,
            Beer = kronenbourBlanc,
            Quantity = 15
        };
        var shopStock19 = new ShopStock{
            Shop = shop9,
            Beer = moretiAmber,
            Quantity = 10
        };
        var shopStock20 = new ShopStock{
            Shop = shop10,
            Beer = modeloNegra,
            Quantity = 24
        };
        var shopStock21 = new ShopStock{
            Shop = shop10,
            Beer = asahiGinger,
            Quantity = 7
        };
        var shopStock22 = new ShopStock{
            Shop = shop11,
            Beer = leffeBlonde,
            Quantity = 28
        };
        var shopStock23 = new ShopStock{
            Shop = shop11,
            Beer = chimayRed,
            Quantity = 19
        };
        var shopStock24 = new ShopStock{
            Shop = shop12,
            Beer = leffeBrune,
            Quantity = 23
        };
        var shopStock25 = new ShopStock{
            Shop = shop12,
            Beer = guinnessExtra,
            Quantity = 11
        };
        var shopStock26 = new ShopStock{
            Shop = shop13,
            Beer = heinekeenLager,
            Quantity = 16
        };
        var shopStock27 = new ShopStock{
            Shop = shop13,
            Beer = carlsbergPilsner,
            Quantity = 20
        };
        var shopStock28 = new ShopStock{
            Shop = shop13,
            Beer = kronenbourg1664,
            Quantity = 14
        };
        var shopStock29 = new ShopStock{
            Shop = shop14,
            Beer = moretiLager,
            Quantity = 26
        };
        var shopStock30 = new ShopStock{
            Shop = shop14,
            Beer = modeloEspecial,
            Quantity = 6
        };

        // ================ Add the entities to the context and save changes ================
        dbContext.Breweries.AddRange(abbate, chimay, guinness, heineken, carlsberg, kronenbourg, moretti, modelo, asahi);

        dbContext.Beers.AddRange(leffeBlonde, leffeBrune, chimayRed, chimayBlue, chimayTriple, guinnessExtra, heinekeenLager, carlsbergPilsner, kronenbourg1664, moretiLager, modeloEspecial, asahiSuperdry, leffeRadieuse, chimayWhite, guinnessStout, heinekenDark, carlsbergExport, kronenbourBlanc, moretiAmber, modeloNegra, asahiGinger);

        dbContext.BreweryStocks.AddRange(breweryStock1, breweryStock2, breweryStock3, breweryStock4, breweryStock5, breweryStock6, breweryStock7, breweryStock8, breweryStock9, breweryStock10, breweryStock11, breweryStock12);

        dbContext.Wholesalers.AddRange(wholesaler1, wholesaler2, wholesaler3, wholesaler4, wholesaler5, wholesaler6, wholesaler7, wholesaler8, wholesaler9);

        dbContext.WholesalerStocks.AddRange(stock1, stock2, stock3, stock4, stock5, stock6, stock7, stock8, stock9, stock10, stock11, stock12);

        dbContext.Shops.AddRange(shop1, shop2, shop3, shop4, shop5, shop6, shop7, shop8, shop9, shop10, shop11, shop12, shop13, shop14);

        dbContext.ShopStocks.AddRange(shopStock1, shopStock2, shopStock3, shopStock4, shopStock5, shopStock6, shopStock7, shopStock8, shopStock9, shopStock10, shopStock11, shopStock12, shopStock13, shopStock14, shopStock15, shopStock16, shopStock17, shopStock18, shopStock19, shopStock20, shopStock21, shopStock22, shopStock23, shopStock24, shopStock25, shopStock26, shopStock27, shopStock28, shopStock29, shopStock30);

        dbContext.SaveChanges();
    }
}    
