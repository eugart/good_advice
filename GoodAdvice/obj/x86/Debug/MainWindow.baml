   M S B A M L   `   `   `  ����H  DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu  5   	   E AGoodAdvice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GoodAdvice
GoodAdvice 5   	      GoodAdvice.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     5   	   *localclr-namespace:GoodAdvice     5   	   -   5          �Name$  this_��5   	    � Title$ Good Advice��5	   	    � Icon$! image/icons/title/title.ico��5
   	   $
��1020��5   	   $	��540��6   $	��800��5   	   $	��600��6   $
��1020��5   	   $
��1080��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � -   5        $��mainGrid��5      .+�5   
    � -   5          �Name$ ContentFrame��5      5      !   HamburgerMenu.HamburgerMenu  5   
   -   5        $��hamMenu��5      
���   �   MenuIconColor
 �����   SelectionIndicatorColor
 � ���   MenuItemForeground
 �����$
��Left=�5      $��
0, 0, 0, 0q�5       J� Opacity$
 0.65Q�5      	   Content	 5      %   HamburgerMenu.HamburgerMenuItem  -   5        $��item1��5   2   
   Icon$%
 image/icons/hamburgerMenu/0.ico��6?      Text$ Главная��6f      SelectionCommand 6u   ��  �� ElementName$ this_��6�     5       -   5        $��item2��5    2   $%
 image/icons/hamburgerMenu/1.ico��6?   $1 +Текущее местоположение��6f   6�     5!      -   5        $%
 image/icons/hamburgerMenu/5.ico��5!   2   $3 -Изменить местоположение��6Y   6x     5"      -   5        $��item3��5"   2   $%
 image/icons/hamburgerMenu/2.ico��6?   $# Поиск автомойки��6f   6}     5#      -	   5        $%
 image/icons/hamburgerMenu/3.ico��5#   2   $ Настройки��6Y   6j     5$      -
   5        $%
 image/icons/hamburgerMenu/4.ico��5$   2   $ Энциклопедия��6Y   6m   5&      5'      5(      