   M S B A M L   `   `   `  ����H  DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu  5   	   E AGoodAdvice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GoodAdvice
GoodAdvice 5   	      GoodAdvice.Main   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     5   	   *localclr-namespace:GoodAdvice     5   	     N� Title$  Good Advice��5	   	   $
��Auto��5
   	   $
��Auto��6    � 	Resources 5         ButtonTemplate �� 
TargetType �� Padding �� CornerRadius �� Triggers :� RoutedEvent ��Name �� 
TargetName	 �� TargetProperty
 g� AutoReverse	 �� To g� Duration��%  &	        �� 5   
   " ��61   .R�5      �� $��Border��5      
��� ���$��3q�5      $
 0, 2q�5      
���   �$ 10��5      
��� ���._�5      �� ��. 6@   5       5      :� 5      $ 
MouseEnter��6   .[�5      �� $ 
MouseEnter��6&   .��5      �� .��5      �� $ Border��5   -   $*	 $(Background).(SolidColorBrush.Color)�5   -   
 .  $ OrangeX�5    -   $ 0:0:0.1D�5!   -   �� 5"      $ Border��5#   -   $4	 .(TextBlock.Foreground).(SolidColorBrush.Color)�5$   -   
 .  $ WhiteX�5&   -   $ 0:0:0.1D�5'   -   5(      5)      5*      :� 5+      $ 
MouseLeave��6   .[�5,      �� $ 
MouseLeave��6&   .��5-      �� .��5.      �� $ Border��5/   -   $*	 $(Background).(SolidColorBrush.Color)�50   -   
 .  $ BlackX�52   -   $ 0:0:0.1D�53   -   �� 54      $ Border��55   -   $4	 .(TextBlock.Foreground).(SolidColorBrush.Color)�56   -   
 .  $ OrangeX�58   -   $ 0:0:0.1D�59   -   5:      5;      5<      5?      5@      .��5B      � ��5C   
   �� 5D       �� ImageSource$ /image/background/bg.png��6    j� Stretch$ UniformToFill=�6@   .+�5G   
   � 
���   � J� Opacity$
 0.65Q�6"   $��310,150,10,30q�61   .+�5I      (�  (� Stretch$ Uniform=�6   $	��Top=�6(   .��5J      �� -   5         ��Name$ textBox1��5J      $2��,Хотите помыть свой авто?��6,   
���   �$��0q�6_   
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�6�   5K      (� 5M      $ Uniform=�6   $	��Top=�6(   .��5N      �� -   5        $ textBox2��5N      $��0, 25, 85, 0q�6,   $��А вдруг дождь?��6B   
���   �$��0q�6m   
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�6�   5O      (� 5Q      $ Uniform=�6   $	��Top=�6(   .��5R      �� -   5        $ textBox3��5R      $��95, 52, 0, 0q�6,   $3��-Получите совет на основе��6B   
���   �$��0q�6w   
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Bold)�6�   5S      (� 5U      $ Uniform=�6   $	��Top=�6(   .��5V      �� -   5        $ textBox4��5V      $��145, 74, 0, 0q�6,   $(��"прогноза погоды на��6C   
���   �$��0q�6r   
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Bold)�6�   5W      (� 5Y      $ Uniform=�6   $	��Top=�6(   .��5Z      �� -   5        $ textBox5��5Z      $��145, 85, 0, 0q�6,   $$��последующие дни.��6C   
���   �$��0q�6p   
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Bold)�6�   5[      (� 5]      $
 None=�6   $��Bottom=�6%   .��5^      �� #��[  5_      $��0, 0, 0, 10q�5`      $��Bottom=�5a      $��Center=�5b      $��50��5c      $	��250��5d      $��35(�5e      $2��,/GoodAdvice;component/Fonts/#Bebas Neue Book)�5f       �� TextAlignment$ Center=�5g      $2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�66   .��5h       Мыть или не мыть?5j      5k      5l       � 5m   
   -   5          �Name$ ContentFrame��5m      6&   5n      5o      