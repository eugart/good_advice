   M S B A M L   `   `   `  ����H  DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu  5   	   E AGoodAdvice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GoodAdvice
GoodAdvice 5   	      GoodAdvice.Settings   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     5   	   *localclr-namespace:GoodAdvice     5   	     N� Title$  Good Advice��5	   	   $
��Auto��5
   	   $
��Auto��6    � 	Resources 5         CheckRadioFocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  SliderCheckBox �� 
TargetType �� 
TargetType � 	Resources  Key	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value �� 
Background �� Bullet ��Name �� CornerRadius J� RenderTransformOrigin J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   	Direction �� Triggers P� Property P� Value �� 
TargetName N� EnterActions ��Name  StoryboardIsChecked �� BeginStoryboardName  StoryboardIsCheckedOff��%	  &	        &	 �     7   7  7  �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��14,0,0,0q�6$    . #��� ��6Q   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   " ��6'   .�5      ��  � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&    5      ���� 5      StoryboardIsChecked .��5   "   U� $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6@   $
 	CheckFlag��6�   .\�5   &     $ 0��6;   $ 0Q�6G     5    &   $ 0:0:0.2��6;   $ 14Q�6M   5!   #   5"      �� 5#      StoryboardIsCheckedOff .��5$   "   U� $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6@   $
 	CheckFlag��6�   .\�5%   &     $ 0��6;   $ 14Q�6G     5&   &   $ 0:0:0.2��6;   $ 0Q�6M   5'   #   5(      5)      .R�5*      �� 
 ����  .  5+      �� 5,   "   $ ForegroundPanel��6)   $��1q�6B   $��35��6V   $��20��6a   $ 10��6m   ._�5-   &   �� .+�5.   *   �� $ 	CheckFlag��6D   
�������$ 10��6W   $��Center=�6i   $��1q�6�   $��19��6�   $��18��6�   $ 0.5,0.5&�6�   z�5/   .   V� 50   2   .~�51   6   �� �� 52   6   �� 53   6   T� 54   6   55   3    57   .     58   2   $ 1Q�6C   $	 180Q�6S   5:   +   5;   '   5<   #   ._�5>      �� #��z��6/   #��z��6r   ��. # z 6�   $��Center=�6�   5?       5@      P� 5A       � �� . . �5B   "   �� 8    �@�FocusVisualStyle6E   �� 5C   "    � ��$ 4,0,0,0q�6<   5D      P� 5E       � {� .  . �5F   "   �� # � ��6?    � ��5G      P� 5H       �@d�	IsChecked$
 TrueY�6;   . �5I   "   �� $ ForegroundPanel��6)    � ��
 � � �6\    5J   "   �� 5K   &   $  BeginStoryboardCheckedTrue��66   8�� 6Z   �� 5L   &   $! BeginStoryboardCheckedFalse��67   5N      P� 5O       �@d�	IsChecked$ FalseY�6;   . �5P   "   �� $ ForegroundPanel��6)    � ��
 � ���6\    5Q   "   �� 5R   &   $! BeginStoryboardCheckedFalse��66   8�� 6[   �� 5S   &   $  BeginStoryboardCheckedTrue��67   5U      5W      5Y      5Z      5[      .��5\      � .+�5]   
   � 
���   � J� Opacity$
 0.65Q�5^      $��
250,0,10,0q�5_      $	��170��5`      $	��Top=�5a      .+�5b      �� -   5         ��Name$ label0��5b      $��Center=�5c      $	��Top=�5d      $��0,10,0,0q�5e      $ 1Q�5f      $��0q�5g      
�������$��40(�5i      $2��,/GoodAdvice;component/fonts/#Bebas Neue Bold)�5j      .��6N   Настройки5l      (� 5m      $	��Top=�6   $
��Left=�5n      $��0, 85, 0, 0q�5o      .��5p      �� -   5        $ label1��5p      $
��Left=�5q      $ 1Q�5r      $��0, 0, 20, 0q�5s      $��0q�5t      
�������$2��,/GoodAdvice;component/fonts/#Bebas Neue Book)�5v      .��6R   dbСохранить местоположение после завершения программы5x      5y      5{      �� 5|   
   -   5        $
��chb1��5|      #���  6   $	��Top=�6H   $��Right=�6`   $��0, 100, 20, 0q�6|   6�    � 5}   
   -   5          �Name$ ContentFrame��5}      6&   5~      5      