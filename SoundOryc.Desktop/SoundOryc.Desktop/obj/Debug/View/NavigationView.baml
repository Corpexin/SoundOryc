   M S B A M L   `   `   `  ����L  HSoundOryc.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SoundOryc.Desktop.ViewSoundOryc.Desktop.View  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command 5	      +    %SoundOryc.Desktop.View.NavigationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SoundOryc.Desktop.View     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5      WcmdMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform  5	      $	��600��5
        � DataContext  5      �� *Nav+   Locator �� Source# [   � 	Resources 5       �� MergedDictionaries �� Source  	boolToVis�� 5   
    5      �� 5      $ Resources.xaml?�6&   %   &	       �� 5      6+   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��197* �6   �� 5      $
��100* �6   �� 5      $��44 �6   �� 5      $	��91* �6   �� 5      $
��197* �6   .+�5   
   �� $��2��6   |�.   J� IsHitTestVisible .   � OverridesDefaultStyle . $��Center=�6l   $��13��6�   $��17��6�   $��
0,-23,0,47q�6�   ��5       !� 5!        logo !� Visual# [ 6   5#      �� 5$   
   -   5        $��
btnSideBar��5$   .   $��0��6   $��0��6!   $��12,-21,0,48q�6@     settings#��[ 6V   |�.  $��0q�6�    . $��Stretch=�6�   $
��Left=�6  $��18��66  $��1(�6B  $��10��6O  $��18��6[  ��6z   Z� ��6�   Z� ��6�   Z� .  (System.Windows.Interactivity.Interaction	   Triggers	 5%      /  )System.Windows.Interactivity.EventTrigger  5&      
   	EventName$
 Click��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5'      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6)   �� *openCloseSidebar+5(      5*      �� 5+   
   -   5         ��Name$ tbSearch��5+      $��0��6$   $��0��64   $��
90,14,90,5q�6�   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$&  Search songs, artists, albums...��6�      ClearTextButton .   �� TextWrapping$ WrapWithOverflow=�6  $��13(�6,   � ToolTip$&  Search songs, artists, albums...��6:  $��Stretch=�6e  $��20,0,0,0q�6�  $��5��6�  ���#898c88��6B   �� *
searchText+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�   5,       �� 
TargetType �� Property �� Value��%_   '��       �� 5-      " ��6   .�5.      ��  �@��CornerRadius$ 12��65   5/      50      .��6!    J� InputBindings 51      �� 52      
 �� Key$ Enter��6    �� Command 6)   �� *searchContent+ �� CommandParameter 6K   ��  �� Path$
 Text� �� RelativeSource ��  �� AncestorType" ��.��53   %   54      �� 56   
   -   5         ��Name$ 	btnEngine��56        ButtonStyle#��[ 6%   $��15��6K   $��15��6X   
������ $��0,0,0,0q�6}   $��0,0,0,0q�6�   $��1(�6�   {�. $��1��6�   $y�Visible=�6�   $��4��6�   $��0��6�   $��0,19,126,11q�6
  $��Right=�6   $  Search with Netease engine��6<  .��57      �� ��58      �� 59      " ��6   .�5:      ��  � ��$ /Resources/netease.png��63    �� Triggers 5;      �� 5<       �� Binding 6*   �� *isNeteaseEngineSelected+  �� Value	  False6V   .a�5=   "   ��  � ��$ /Resources/mp3with.png��6;   5>      5@      5B      	 5C        5D      $
 Click��6!   . 5E         6)   �� *searchContent+5F      5H      �� 5I   
   -   5        $ btnSelectEngine��5I        selectEngineButtonStyle#��[ 6+   $��8��6\   $��10��6h   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��1(�6�   {�. $��1��6�   $y�Visible=�6�   $��4��6�   $��0��6  $��0,23,109,12q�6  $��Right=�60  $ Select Search Engine��6L  	 5J        5K      $
 Click��6!   . 5L         6)   �� *openCloseEngineSelection+5M      5O      ]� 5P   
   -   5        ! ]�Name$! dpEngineSelection��5P      $��4��6/   $��0,0,125,-10q�6@   $��Right=�6�   $��27��6�   y�6U   �� *isEngineSelectionOpened+" �� 	Converter#" [ .+�5Q      �� ���#898c88$��1q�6-   $��
5, 0, 5, 0q�6A   .@�5R      �� .��5S      �� -   5        $ 
btnNetease��5S        neteaseButtonStyle#��[ 62   $��15��6_   $��15��6l   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��1(�6�   {�. $��1��6�   $y�Visible=�6�   $��4��6  $��0��6  $��Right=�6  $  Search with Netease engine��6;  	 5T        5U      $
 Click��6-   . 5V   "      65   �� *selectedEngineNetease+5W      5Y      5Z      �� 5[      .��5\      �� -   5        $ 
btnMp3With��5\        mp3WithButtonStyle#��[ 62   $��15��6_   $��15��6l   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��1(�6�   {�. $��1��6�   $y�Visible=�6�   $��4��6  $��0��6  $��Right=�6  $  Search with Mp3With engine��6;  	 5]        5^      $
 Click��6-   . 5_   "      65   �� *selectedEngineMp3With+5`      5b      5c      5d      5e      5f      5g      