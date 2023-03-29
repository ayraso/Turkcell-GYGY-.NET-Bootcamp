using OpenClosed;

Google google = new Google();
Brave Brave = new Brave(google);

Brave.Search("2023 seçim saati");

Yandex yandex = new Yandex();
Brave.ChangeDefaultBrowserTo(yandex);

Brave.Search("vakanümist ne demek");

Brave.ClearSearchHistory();

