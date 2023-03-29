using OpenClosed;

Google Google = new Google();
Brave Brave = new Brave(Google);

Brave.Search("2023 seçim saati");

Yandex yandex = new Yandex();
Brave.ChangeDefaultBrowserTo(yandex);

Brave.Search("vakanümist ne demek");

Brave.ClearSearchHistory();

GoogleChrome Chrome = new GoogleChrome(Google);
Chrome.Search("siyanobakterilerin karbodioksit tüketim kapasitesi");
