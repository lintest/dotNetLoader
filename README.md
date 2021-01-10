Подключение библиотеки внешних компонент Native API

Статьи, рекомендации
 * [.NET-обёртки нативных библиотек на C++/CLI](https://habr.com/ru/post/318224/)
 * [Unmanaged C++ library в .NET. Полная интеграция](https://habr.com/ru/company/simbirsoft/blog/276011/)

[Установка пакета SDK](https://docs.microsoft.com/ru-ru/dotnet/core/install/linux-ubuntu)

```bash
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0

```
