   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4ffCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs  5      V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	       SoundOryc.Desktop,   &SoundOryc.Desktop.View.LoginDialogView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      WdialogsCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ;controls,http://metro.mahapps.com/winfx/xaml/controls   5      Gmetro;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro   5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity   5	      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5
        � DataContext  5      �� *Login+   Locator �� Source# [   � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Resources.xaml?�6&   �� 5      $X Rpack://application:,,,/MahApps.Metro;component/Themes/Dialogs/BaseMetroDialog.xaml?�6%   %    5      4   .MahApps.Metro.Controls.Dialogs.BaseMetroDialog   	DialogTop 5      ]� 5   
   $��Center=�6   $	��500��61   .+�5      �� -   5         ��Name$
 lbl2��5      $
��Left=�6#   $��Login��69   $��100, 10, 10, 10q�6I   
�������$��21.333(�6t   �� 5      -   5         ��Name$ closeLDialogButton��5      $��Right=�61     ButtonStyle#��[ 6H     closeDialogButton#���  6m   $��10��6�   $��10��6�   
������ $	��Top=�6�   $��Right=�6�   $��
4,15,14,10q�6   
������ $��0,0,0,0q�6.  $��0,0,0,0q�6@  $��1(�6Z  {�. $��1��6y  $y�Visible=�6�  ��6�  �� *closeLoginDialog+5      ��5!      � 5$   
   $��-40,-50,-40,17q�6   $��Center=�6'   $	��330��6D    � RowDefinitions 5&      �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    .+�5.      �� $��20, 0, 0, 0q�6   $��Email��6)   $��0��6:   ���	#FF898C886G   �� 5/      -   5        	 ��Name$	 tbLUsername��5/        TextBoxStyle1#��[ 6+   $��1��6R   $��
10,0,10,10q�6}   
 �� TextWrapping$
 WrapWithOverflow=�6�   $��13(�6�    � ToolTip$ write email��6�   $��Stretch=�6�   $��	20,2,20,3q�6�   $��5��6  ���#2b323a���	#FF767676 �� 
CaretBrush �	#FF999999���	#FF787878 �� SelectionBrush �	#FF2B323A��6`   �� *
emailLText+.��6�   50       �� 
TargetType �� Property �� Value��%_   '��       �� 51      " ��6   .�52      ��  �@��CornerRadius$ 12��69   53      54      .��6%   55      �� 56      $��20, 0, 0, 0q�6   $��Password��6)   $��2��6=   ���	#FF898C886J   G� 57      -   5         G�Name$ tbLPassword��57        PassBoxStyle1#��[ 6^   $��3��6�   $��
10,0,10,30q�6�   $��13(�6�   $ write password��6�   $��Stretch=�6�   $��	20,2,20,3q�6�   $��5��6  ���#2b323a���	#FF898C88 J� InputBindings 58      �� 59      
 �� Key$ Enter��6!    �� Command 6-   �� *
loginAcc+ �� CommandParameter 6J   ��  �� Path$
 Text� �� RelativeSource ��  �� AncestorType" G�5;      �� 5>      -   5        $ 
lblRInfoRL��5>      $��4��6(   ���	#FF898C88$��0,25,0,4q�6M   ��6_   �� *	infoLText+5?         DialogBottom 5A      �� 5B   
   -   5        $ 	btnLLogin��5B        ButtonTextStyle#��[ 6$   $��15(�6O   $
��Thin"�6]   $��login��6o    �� 	ClickMode$ Press=�6�   $	��100��6�   $��25��6�   $��Center=�6�   $��Stretch=�6�   $	��Top=�6�   $��Disabled=�6  $��	10,2,10,5q�6?   � UseLayoutRounding .  ��6n  �� *
loginAcc+5C      5E      