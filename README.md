# CountriesAPI

For the database this API is using a JSON list of countries I published on [Gist](https://gist.github.com/tmrk/3ba1cc679e9f655143593524a203b7e2), which is based on a country list database [published by the UN](https://unstats.un.org/unsd/methodology/m49/). 

## Options 

The following parameters are avalable for querying:

* `keys` - Specify which country keys to include in the response objects. Multiple values are separated by commas. If empty, all keys are returned.

### Unique value keys

Each country has a unique value for these keys. However, if you'd like to return more than one country, just separate their values by commas, like this `name=Sweden,Norway,Denmark`

* `name` - The name of the country in English
* `nameFrench` - The name of the country in French
* `nameSpanish` - The name of the country in Spanish
* `nameRussian` - The name of the country in Russian
* `nameChinese` - The name of the country in Chinese
* `nameArabic` - The name of the country in Chinese
* `alpha2` - A unique two-digit alphabetical code
* `alpha3` - A three-digit alphabetical code assigned by the International Organization for Standardization (ISO)
* `m49code` - M49 is a unique three digit country code, standardised by the Statistics Division of the UN Secretariat.

### Multiple value keys

These act like categories and will return multiple values

* `region`
* `subRegion`
* `intermediateRegion`
* `LDC` - Least Developed Countries, as defined by the UNSD
* `LLDC` - Land Locked Developing Countries, as defined by UNSD

## Example

An example query would look like this, to return in sub-region 061 (which is *Polynesia*) and only show their `name`, `nameFrench` and `alpha3` fields

```
https://localhost:7146/Countries?keys=name,nameFrench,alpha3&subRegion=061
```
The response would be the following:

```JSON
[
  {
    "name": "American Samoa",
    "nameFrench": "Samoa américaines",
    "alpha3": "ASM"
  },
  {
    "name": "Cook Islands",
    "nameFrench": "Îles Cook",
    "alpha3": "COK"
  },
  {
    "name": "French Polynesia",
    "nameFrench": "Polynésie française",
    "alpha3": "PYF"
  },
  {
    "name": "Niue",
    "nameFrench": "Nioué",
    "alpha3": "NIU"
  },
  {
    "name": "Pitcairn",
    "nameFrench": "Pitcairn",
    "alpha3": "PCN"
  },
  {
    "name": "Samoa",
    "nameFrench": "Samoa",
    "alpha3": "WSM"
  },
  {
    "name": "Tokelau",
    "nameFrench": "Tokélaou",
    "alpha3": "TKL"
  },
  {
    "name": "Tonga",
    "nameFrench": "Tonga",
    "alpha3": "TON"
  },
  {
    "name": "Tuvalu",
    "nameFrench": "Tuvalu",
    "alpha3": "TUV"
  },
  {
    "name": "Wallis and Futuna Islands",
    "nameFrench": "Îles Wallis-et-Futuna",
    "alpha3": "WLF"
  }
]
```

## Demo

This project is currently not deployed anywhere. 

If you'd like to try it, just clone the repository and use Visual Studio to run it with **.NET Core Web API** and **Swagger**.
