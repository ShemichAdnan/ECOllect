using System.Collections.ObjectModel;
using System.Web;
using ECOllect.Models;

namespace ECOllect.ViewModels;

public class MapViewModel : BaseViewModel
{
    public ObservableCollection<CommunityAction> Actions { get; private set; }
    public string MapHtml { get; private set; }

    public MapViewModel()
    {
        Actions = SampleData.GetSampleActions();
        GenerateMapHtml();
    }

    private void GenerateMapHtml()
    {
        MapHtml = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <link rel='stylesheet' href='https://unpkg.com/leaflet@1.7.1/dist/leaflet.css'/>
    <script src='https://unpkg.com/leaflet@1.7.1/dist/leaflet.js'></script>
    <style>
        body, html {{ height: 100%; margin: 0; padding: 0; }}
        #map {{ position: absolute; top: 0; bottom: 0; width: 100%; height: 100%; }}
        .custom-popup {{ 
            cursor: pointer;
            color: black;
            text-decoration: none;
            font-weight: bold;
            font-size: 16px;
            margin-bottom: 8px;
            text-align: center;
        }}
        .popup-container {{
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 8px;
            min-width: 200px;
            padding: 8px;
        }}
    </style>
</head>
<body>
    <div id='map'></div>
    <script>
        function openActionDetail(id) {{
            window.location.href = 'hybrid:openAction:' + id;
        }}

        window.onload = function() {{
            var map = L.map('map');
            L.tileLayer('https://{{s}}.tile.openstreetmap.org/{{z}}/{{x}}/{{y}}.png', {{
                attribution: '© OpenStreetMap contributors'
            }}).addTo(map);
            map.setView([44.2037, 17.9239], 13);

            var markers = [
                {string.Join(",\n                ", Actions.Select((action, index) =>
                    $"{{ id: {index}, " +
                    $"lat: {action.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                    $"lng: {action.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                    $"title: '{HttpUtility.JavaScriptStringEncode(action.Title)}' }}"
                ))}
            ];

            markers.forEach(function(marker) {{
                var container = document.createElement('div');
                container.className = 'popup-container';

                var title = document.createElement('div');
                title.className = 'custom-popup';
                title.textContent = marker.title;
                container.appendChild(title);

                container.onclick = function() {{ 
                    openActionDetail(marker.id); 
                }};
                
                L.marker([marker.lat, marker.lng])
                 .addTo(map)
                 .bindPopup(container, {{
                    maxWidth: 220,
                    minWidth: 200
                 }});
            }});
        }};
    </script>
</body>
</html>";
    }
}

