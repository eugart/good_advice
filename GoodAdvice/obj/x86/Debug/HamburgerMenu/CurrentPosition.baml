   M S B A M L   `   `   `  ����H  DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu  5   	   E AGoodAdvice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GoodAdvice
GoodAdvice 5   	       GoodAdvice.CurrentPosition   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     5   	   *localclr-namespace:GoodAdvice     5   	   a ]Awesomium.Windows.Controls, Version=1.7.5.1, Culture=neutral, PublicKeyToken=7a34e179b8b61c39,awe"http://schemas.awesomium.com/winfx  5   	     N� Title$  Good Advice��5
   	   $
��Auto��5   	   $
��Auto��6    � 	Resources 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5         RoundProgressBarStyle �� 
TargetType �� 	Resources+  %GoodAdvice.RoundProgressPathConverter  Key �� Color �� Property  ProgressBar.Progress �� Value  ProgressBar.Background  ProgressBar.Border �� 
TargetType �Name'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard g� RepeatBehavior �� TargetProperty �� 
TargetName W� From	 W� To g� Duration �� Stretch  Conv `� 	Converter  RelativeThickness `� ConverterParameter  One �� Source  Zero �� Path �� RelativeSource J� RenderTransformOrigin 	 IndeterminatePart �� Triggers P� Property P� Value �� 
TargetName 
 ButtonTemplate �� Padding �� CornerRadius :� RoutedEvent  ��Name! g� AutoReverse	" �� To��5      %�  &	        7  7  7  7  7  7  7  7  7  7  7  7  7 	 7  7  &	
 )    �� 5   
   0sys&clr-namespace:System;assembly=mscorlib  5      " �5   .    5      ��  5      Conv 63   X�5      RelativeThickness 0.75Q�6=   X�5      Zero 0.0Q�6/   X�5      One 1.0Q�6.   X�5      IndeterminatePart 0.25Q�6=   �� 5      ProgressBar.Progress $ 	#FF06B025��6?   �� 5      ProgressBar.Background $ 	#FFE6E6E6��6A   �� 5      ProgressBar.Border $ 	#FFBCBCBC��6=   5       .�5!      ��  � ��8   6+   �� 5"       � ��8  6+   �� 5#       � ��8  6,   �� 5$       � ��$ 1q�60   �� 5%       � �� 5&      �� 5'      " �6&   .R�5(      � $ TemplateRoot��6   	 5*        5+   "   CommonStates��.
 5,   &     Determinate��62     5-   &   Indeterminate��. 5.   *   �� $ Forever��65   .��5/   .   W� $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�50   )   $ 	Animation��51   )   $ 0X�52   )   $	 360X�62   $ 0:0:2D�6;   53   +   54   '   55   #   .+�59      F� #��z��6#   $ Uniform=�6G   #��z��5:      #��z��6B   ��5;   "   `� 5<   &   8  8  .1�5?   *   �� 8  62   �� 5@   *   8  62   �� 5A   *   8  62   5B   '   5D      F� 5E      $��	Indicator��6Y   #��z��6#   $ Uniform=�6G   ��5F   "   `� 5G   &   8  8 	 .1�5I   *   �� $ Value�62    6?   �� *TemplatedParent+�� 5J   *   $ Minimum�62    6A   �� *TemplatedParent+�� 5K   *   $ Maximum�62    6A   �� *TemplatedParent+5L   '   5N      F� 5P      $��	Animation��6Y   #��z��6#   $ Uniform=�6G   $y�	Collapsed=�5Q      $ 0.5,0.5&�62   ��5R   "   `� 5S   &   8 
 8  .1�5U   *   �� 8  62   �� 5V   *   8  62   �� 5W   *   8  62   5X   '   z�5[   "   �� 5\   &   5^      5_       5`      P� 5b       �@�IsIndeterminate . . �5c   "   �� $ 	Indicator��6?    � y�$ 	Collapsed=�6V   �� 5d   "   $ 	Animation��6?    � y�$ Visible=�6V   5e      5g      5i      5j      �� 5l   
   " ��61   .R�5m      �� $��Border��5n      
��� ���$��3q�5p      $
 0, 2q�5q      
���   �$ 10��5s      
��� ���._�5u      �� ��. 6@   5v       5w      :� 5x      $ 
MouseEnter��6   .[�5y      �� $  
MouseEnter��6&   .��5z      �� .��5{      �� $ Border��5|   -   $* $(Background).(SolidColorBrush.Color)�5}   -   ! .  $" OrangeX�5   -   $ 0:0:0.1D�5�   -   �� 5�      $ Border��5�   -   $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�5�   -   ! .  $" WhiteX�5�   -   $ 0:0:0.1D�5�   -   5�      5�      5�      :� 5�      $ 
MouseLeave��6   .[�5�      �� $  
MouseLeave��6&   .��5�      �� .��5�      �� $ Border��5�   -   $* $(Background).(SolidColorBrush.Color)�5�   -   ! .  $" BlackX�5�   -   $ 0:0:0.1D�5�   -   �� 5�      $ Border��5�   -   $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�5�   -   ! .  $" OrangeX�5�   -   $ 0:0:0.1D�5�   -   5�      5�      5�      5�      5�      .��5�      � .+�5�   
   � -   5        $��BG��5�      
���   �# J� Opacity$
# 0.65Q�5�      5�      (� 5�   
   -   5        $��viewBox1��5�   ?   $ (� Stretch$$ Uniform=�6   $��Center=�6$   .��5�      �� -   5        $��textBox��5�      % �� 
IsReadOnly% . $
# 0.75Q�5�      $��50, 0, 50, 50q�5�      $��Center=�5�      $I��CОпределение вашего местоположения...��5�      
�������
���   �$��0q�5�      $2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�5�      5�      � 5�   
   -   5        $��PB��5�      & � Value$	& 0.7Q�6"   ' � Maximum$' 1Q�6.   $��90��6:   $��90��6F   #���   5�      ���	#FFED1C24���	#FFEBB249( � IsIndeterminate( . 5�      �� 5�   
   -   5        $��picture��5�      $��/image/progessBar/pb.ico��6#   $
��None=�6E   $��
0,1.5,-2,0q�6T   � 5�   
   -   5        $��WP��5�      $��110,150,110,230q�6   
���   �$
# 0.65Q�6H   $y�Hidden=�6W   $	��200��6k   .+�5�      (� -   5        $��viewBox2��5�   @   $$ Uniform=�6   $	��Top=�6(   .��5�      �� -   5        $��textBox2��5�      $	��Top=�6*   $��Center=�6B   
���   �
�������$��0q�6�   $2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�6�   5�      (� 5�      -	   5        $��viewBox5��5�   @   $$ Uniform=�6   $	��Top=�6(   $y�	Collapsed=�6P   .��5�      �� -
   5        $��textBox3��5�      $N��HУкажите свое местоположение вручную.....��6*   $	��Top=�6]   $��Center=�6u   
���   �
�������$��0q�6�   $2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�6�   5�      (� 5�      -   5        $��viewBox3��5�   C   $$ Uniform=�6   $��Bottom=�6(   .��5�      �� -   5        $
��but1��5�      ) �� 	IsDefault) . #��[
 5�      $��30, 100, 350, 10q�5�      $��50��5�      $	��250��5�      $��35(�5�      $2��,/GoodAdvice;component/Fonts/#Bebas Neue Book)�5�      * �� TextAlignment$* Center=�5�      $2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�6:   .��5�      Да6   5�      (� 5�      -   5        $��viewBox4��5�   C   $$ Uniform=�6   $��Bottom=�6(   .��5�      �� -   5        $
��but2��5�      + �� IsCancel+ . #��[
 5�      $��350, 100, 30, 10q�5�      $��50��5�      $	��250��5�      $��35(�5�      $2��,/GoodAdvice;component/Fonts/#Bebas Neue Book)�5�      $* Center=�5�      $2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�6:   .��5�      Нет6   5�      (� 5�      -   5        $��viewBox6��5�   ^   $$ Uniform=�6   $��Bottom=�6(   $
��Left=�6C   $y�	Collapsed=�6n   $	��100��6�   $	��450��6�   $	��400��6�   $��10, 0, 0 10q�6�   .��5�      �� -   5        $��textBox4��5�   1   |�. $2��,Введите название города��5�      $��5q�5�      
��� ���, �� TextAlignment$, Center=�5�      $��80(�6C   $	��100��6Q   $	��750��6^   $	��Top=�6j   $
��Left=�6�   
�������
���   �$2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�6�   6>  5�      (� 5�      $��Right=�6   $��Bottom=�62   $��70��6M   $��70��6X   $��50, 0, 0, 0q�6d   .��5�      �� -   5        $��picture2��5�      $��/image/state/state1.ico��6,   $
��None=�6M   $��Bottom=�6\   $��Right=�6w   $y�	Collapsed=�6�   $��0, 0, 10, 13q�6�   5�      (� 5�      $��Right=�6   $��Bottom=�62   $��70��6M   $��70��6X   $��50, 0, 0, 0q�6d   .��5�      �� -   5        $��picture3��5�      $��/image/state/state2.ico��6,   $
��None=�6M   $��Bottom=�6\   $��Right=�6w   $y�	Collapsed=�6�   $��0, 0, 10, 13q�6�   5�      5�      (� 5�   
   -   5        $��viewBox7��5�   ?   $$ Uniform=�6   $��Center=�6$   $y�	Collapsed=�6O   $	��100��6f   $	��300��6t   $��0, 250, 0, 0q�6�   .��5�      �� -   5        $
��but3��5�      + . #��[
 5�      $
# 0.65Q�5�      $	��250��5�      $��35(�5�      $2��,/GoodAdvice;component/Fonts/#Bebas Neue Book)�5�      $* Center=�5�      $2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�6:   .��5�      Подтвердить6'   5�       � 5�   
   -   5        -  �Name$- ContentFrame��5�      6&   5�      5�      