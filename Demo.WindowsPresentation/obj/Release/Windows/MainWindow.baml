   M S B A M L   `   `   `  ���� _  [Demo.WindowsPresentation, Version=1.7.0.0, Culture=neutral, PublicKeyToken=b85b9027b614afefC&clr-namespace:Demo.WindowsPresentationDemo.WindowsPresentation  )    #Demo.WindowsPresentation.MainWindow   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    4src&clr-namespace:Demo.WindowsPresentation    -     � Title$4  .GMap.NET - Great Maps for Windows Presentation��$	��775��$	��888�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$
 Once=�$	��775��$	��600�� � 	Resources    ZoomUpButton �� 
TargetType �� Property �� Value �� 
TargetType	 �� Triggers
 P� Property P� Value3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth  ZoomDownButton��%^  &	        &	 %    �� " ��.���  � ��$
 23.5����  � ��$
 25.5����  � �� �� " ��.R�� $
��23.5��$
��25.5��.+��� $=��7/Demo.WindowsPresentation;component/Resources/zoom+.png��$
��Fill=��� $��Center=�	 P� 
 �@J�IsMouseOver . . ���  �@J�Effect   $ 2Q��� " ��.���  � ��$
 23.5����  � ��$
 25.5����  � �� �� " ��.R�� $
��23.5��$
��25.5��.+��� $=��7/Demo.WindowsPresentation;component/Resources/zoom-.png��$
��Fill=��� $��Center=�	 P� 
 �@J�IsMouseOver . . ���  �@J�Effect   $ 2Q�.��� .+��� -   $��mapgroup��$
��gmap��$��12,7,241,12q�$��Stretch=�$��Stretch=�.��"   Demo.WindowsPresentation.Map  -     Name$ MainMap��c _GMap.NET.WindowsPresentation, Version=1.7.0.0, Culture=neutral, PublicKeyToken=b85b9027b614afef.  (GMap.NET.WindowsPresentation.GMapControl   Zoom$ 13Q�   MaxZoom$ 24��   MinZoom$ 1���� $��Right=�$��
0,7,186,12q�$��Stretch=�$
��Zoom��.��� .+��� -    ��Name$ 	czuZoomUp��#��[  $��Center=�$	��Top=�$
��23.5��$
��25.5���� -    ��Name$ 
sliderZoom�� �� Orientation$ Vertical=�$��Center=�$��Stretch=� � Maximum$ 17Q� � Minimum$ 12Q� �� TickPlacement$
 Both=�$��	0,35,0,35q� � SmallChange$ 1Q� � Value ��  �� ElementName$ MainMap�� �� Path$
 Zoom��� -   $ czuZoomDown��#��[ $��Center=�$��Bottom=�$��23��$��25���� -   $��	groupBox2��$
��gmap��$��Right=�$��
0,158,12,0q�$	��169��$	��Top=�$	��135��.��� $��Stretch=�$��Stretch=�.+��� -   $��comboBoxMapType��$��12(�$��6,6,45,0q�$��25.04��$	��Top=� �� SelectedItem �� $ MapProvider�$ MainMap�� �� ValidationRules 0   *Demo.WindowsPresentation.MapValidationRule  -	   	validator���� -
   $��label1��$��Right=�$��0,6,6,0q�$��33��$��25.04��$	��Top=�.��type�� -   $��checkBoxDragMap��$��6,0,21,6q� d� 	IsChecked$
 TrueY�$��16.04��$��Bottom=�.��
Drag Map�� -   $��checkBoxCurrentMarker��$��16��$��	6,0,45,28q�$
 TrueY�$��Bottom=�.��Current Marker�� -   $��comboBoxMode��$��12(�$��25.04��$��	6,37,45,0q�$	��Top=��� -   $��label5��$��25.04��$��Right=�$��	0,37,-4,0q�$	��Top=�$��43��.��mode�� -   $��button7��$��22��$��Right=�$��Bottom=�$��54��$��
0,0,6,3.06q�.��Save�� -   $��checkBoxDebug��$��16��$��0,0,4,28q�$��Bottom=�$��Right=�$��43��.��Grid�� -   $��	groupBox1��$��coordinates��$	��144��$��Right=�$��0,7,12,0q�$	��Top=�$	��169��.��� .+��� -   $��button1��$��23��$��0,0,6,6q�$��Bottom=�$��Right=�$��71��.��Reload�� -   $��
textBoxLat��$��23��$��6,6,36,0q�$	��Top=��� -   $��
textBoxLng��$��	6,35,36,0q�$��22.04��$	��Top=��� -   $��
textBoxGeo��$��22.04��$��	6,0,36,36q�$��Bottom=�.��lietuva vilnius�� -   $��button2��$��23��$
��Left=�$��6,0,0,7q�$��Bottom=�$��68��.��Go To!�� -   $��label2��$��23��$��Right=�$��0,4,12,0q�$	��Top=�$��27��$��Center=�.��lat�� -   $��label3��$��23��$��Right=�$��	0,33,12,0q�$	��Top=�$��Center=�$��27��.��lng�� -   $��label4��$��23��$��Right=�$��0,0,6,36q�$��Bottom=�$��Center=�$��33��.��geo�� -   $��	groupBox3��$��loading��$��50��$��Right=�$��	0,0,12,12q�$��Bottom=�$	��169��.��� .+�� -   $��progressBar1��$��2q� � IsIndeterminate . �� -   $��	groupBox4��$��Cache��$	��104��$��Right=�$��	0,0,12,68q�$��Bottom=�$	��169��.��� .+��� -   $��button3��$��0,0,12,6q�$��23��$��Bottom=�$��Right=�$��65��.��
Prefetch�� -   $��button4��$��23��$
��Left=�$��6,0,0,6q�$��Bottom=�$��68��.��	Clear All�� -   $��button5��$��Right=�$��0,28.138,12,0q�$��65��$��19.317��$	��Top=�.��Import�� -    $��button6��$
��Left=�$��7,27,0,0q�$��66��$��Center=�$��20.455��$	��Top=�.��Export�� -!   $��checkBoxCacheRoute��$��15��$��8,6,0,0q�$	��Top=�$
��Left=�$��65��.��	routing�� -"   $��checkBoxGeoCache��$��15��$��Right=�$��0,7,0,0q�$	��Top=�$��78��.��	geocoding�� -#   $��	groupBox5��$��	Real Time��$��74��$��Right=�$��
0,471,12,0q�$	��Top=�$	��169��.��� .+�	� -$   $��radioButtonTransport��$��16��$��7,6,36,0q�$	��Top=�.��Transport demo	� -%   $��radioButtonPerformance��$��	6,28,56,0q�$��17.04��$	��Top=�.��Performance	� -&   $��radioButtonNone��$��Right=�$��0,0,-6,7q�$��56��$��16.04��$��Bottom=�$
 TrueY�.��None�� -'   $��markers��$��markers��$��Right=�$	��169��$��0,299,11,283q�$��80��$	��Top=�.��� .+��� -(   $��button8��$��7,6,77,0q�$��21.04��$	��Top=�.��
Add Marker�� -)   $��button10��$��7,0,0,6q�$��21.04��$��Bottom=�$
��Left=�$��56��.��	Clear All�� -*   $��checkBoxPlace��$��Right=�$��0,9,0,0q�$��71��$��16.04��$	��Top=�$
 TrueY�.��
place info�� -+   $��button13��$��78,0,1,5q�$��21.04��$��Bottom=�.��Zoom Center�� -,   $��routes��$��routes��$��Right=�$	��169��$��0,385,11,283q�$��80��$	��Top=�.��� .+��� --   $��button11��$��7,6,0,0q�$��21.04��$	��Top=�$
��Left=�$��65��.��	set start�� -.   $��button9��$��Right=�$��0,6,5,0q�$��65��$��21.04��$	��Top=�.��	set end�� -/   $��button12��$��7,0,6,6q�$��21.04��$��Bottom=�.��	Add route