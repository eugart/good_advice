   M S B A M L   `   `   `  ���� H  DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu  E AGoodAdvice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GoodAdvice
GoodAdvice    GoodAdvice.Main   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     *localclr-namespace:GoodAdvice       N� Title$  Good Advice��$
��Auto��$
��Auto�� � 	Resources    ButtonTemplate �� 
TargetType �� Padding �� CornerRadius �� Triggers :� RoutedEvent ��Name �� 
TargetName	 �� TargetProperty
 g� AutoReverse	 �� To g� Duration��%{  &	        �� " ��.R��� $��Border��
��� ���$��3q�$
 0, 2q�
���   �$ 10��
��� ���._��� ��.  :� $ 
MouseEnter��.[��� $ 
MouseEnter��.���� .���� $ Border��$*	 $(Background).(SolidColorBrush.Color)�
 .  $ OrangeX�$ 0:0:0.1D��� $ Border��$4	 .(TextBlock.Foreground).(SolidColorBrush.Color)�
 .  $ WhiteX�$ 0:0:0.1D�:� $ 
MouseLeave��.[��� $ 
MouseLeave��.���� .���� $ Border��$*	 $(Background).(SolidColorBrush.Color)�
 .  $ BlackX�$ 0:0:0.1D��� $ Border��$4	 .(TextBlock.Foreground).(SolidColorBrush.Color)�
 .  $ OrangeX�$ 0:0:0.1D�.��� ����  �� ImageSource$ /image/background/bg.png�� j� Stretch$ UniformToFill=�.+�� 
���   � J� Opacity$
 0.65Q�$��310,150,10,0q�.+�(�  (� Stretch$ Uniform=�$	��Top=�.���� -    ��Name$ textBox1��$2��,Хотите помыть свой авто?��
���   �$��0q�
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�(� $ Uniform=�$	��Top=�.���� -   $ textBox2��$��0, 25, 85, 0q�$��А вдруг дождь?��
���   �$��0q�
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�(� $ Uniform=�$	��Top=�.���� -   $ textBox3��$��95, 52, 0, 0q�$3��-Получите совет на основе��
���   �$��0q�
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Bold)�(� $ Uniform=�$	��Top=�.���� -   $ textBox4��$��145, 74, 0, 0q�$(��"прогноза погоды на��
���   �$��0q�
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Bold)�(� $ Uniform=�$	��Top=�.���� -   $ textBox5��$��145, 85, 0, 0q�$$��последующие дни.��
���   �$��0q�
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Bold)�(� $
 None=�$��Bottom=�.���� #��[  $��0, 0, 0, 40q�$��Bottom=�$��Center=�$��50��$	��250��$��35(�$2��,/GoodAdvice;component/Fonts/#Bebas Neue Book)� �� TextAlignment$ Center=�$2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�.�� Мыть или не мыть? � -     �Name$ ContentFrame��