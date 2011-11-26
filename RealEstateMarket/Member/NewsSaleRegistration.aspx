<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsSaleRegistration.aspx.cs" Inherits="RealEstateMarket.Member.NewsSaleRegistration" %>
<%@ Register TagPrefix="nixforest" TagName="address" Src="~/CustomControl/AddressControl.ascx" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:ObjectDataSource ID="dataSourceRealEstateType" runat="server" 
        SelectMethod="GetAllRealEstateTypes" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dataSourceNewsSaleType" runat="server"
        SelectMethod="GetAllNewsSaleTypes"         
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dataSourceProject" runat="server" 
        SelectMethod="GetAllProjects" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dataSourceUnit" runat="server" 
        SelectMethod="GetAllUnits" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dataSourceUnitPrice" runat="server" 
        SelectMethod="GetAllUnitPrices" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <h3>
        Đăng tài sản mới
    </h3>
    <asp:Panel ID="pnlBasicInfo" runat="server" BorderStyle="Groove">
        <h4>
            Thông tin cơ bản
        </h4>
        <asp:Label ID="lbl1" runat="server" Font-Bold="true">Điền chính xác các thông tin dưới đây giúp cho 
                tài sản của bạn xuất hiện chính xác và đầy đủ trong các kết quả theo nhu cầu của người dùng, 
                việc này giúp cho giao dịch của bạn sẽ nhanh hơn.</asp:Label><br />
        <br />
        <asp:ValidationSummary ID="validationSum" runat="server"
            ForeColor="Red"
            HeaderText="Vui lòng cập nhật các thông tin tài sản còn thiếu" />
        <asp:Table ID="tblInfo" runat="server" GridLines="Both">
            <asp:TableRow>
                <asp:TableCell>
                    <b>Loại tin rao:</b>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                    <asp:RadioButtonList ID="rblNewsSaleType" runat="server" 
                        DataSourceID="dataSourceNewsSaleType"
                        DataTextField="Name"
                        DataValueField="ID" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Loại Địa ốc:</b>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                    <asp:DropDownList ID="ddlRealEstateType" runat="server"
                        DataSourceID="dataSourceRealEstateType"
                        DataTextField="Name"
                        DataValueField="ID"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Vị trí:</b>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                    <nixforest:address ID="address" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Tên dự án:</b>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList ID="ddlProject" runat="server"
                        DataSourceID="dataSourceProject"
                        DataTextField="Name"
                        DataValueField="ID"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:CheckBox ID="cbProject" runat="server" Text="Khác" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Giá:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxPrice" runat="server" Text="0"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlUnit" runat="server"
                        DataSourceID="dataSourceUnit"
                        DataTextField="Name"
                        DataValueField="ID"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlUnitPrice" runat="server"
                        DataSourceID="dataSourceUnitPrice"
                        DataTextField="Name"
                        DataValueField="ID"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Môi giới:</b>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                    <asp:RadioButtonList ID="cblBroker" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Miễn trung gian</asp:ListItem>
                        <asp:ListItem>Ký gởi môi giới</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Diện tích sử dụng:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxTotalUseArea" runat="server" Text="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTotalUseArea" runat="server"
                        ControlToValidate="tbxTotalUseArea"
                        ErrorMessage="Tổng diện tích sử dụng"
                        ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell>
                    m2
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Diện tích khuôn viên:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxCampusFront" runat="server" Text="Chiều ngang"></asp:TextBox>
                    m <b>X</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxCampusLength" runat="server" Text="Chiều dài"></asp:TextBox>
                    m
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="cbCampusOpenBehind" runat="server"
                        Text="Nở hậu" Font-Bold="true" AutoPostBack="true"
                        oncheckedchanged="cbCampusOpenBehind_CheckedChanged" />
                    <asp:TextBox ID="tbxCampusBehind" runat="server"
                        Text="Chiều ngang sau" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblCampusM" runat="server" Visible="false">m</asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Diện tích xây dựng:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxBuildFront" runat="server" Text="Chiều ngang"></asp:TextBox>
                    m <b>X</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxBuildLength" runat="server" Text="Chiều dài"></asp:TextBox>
                    m
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="cbBuildOpenBehind" runat="server" Text="Nở hậu" Font-Bold="true" 
                        AutoPostBack="true"
                        OnCheckedChanged="cbBuildOpenBehind_CheckedChanged"/>
                    <asp:TextBox ID="tbxBuildBehind" runat="server" Text="Chiều ngang sau" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblBuilM" runat="server" Visible="false">m</asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:ObjectDataSource ID="dataSourceUtility" runat="server" 
        SelectMethod="GetAllUtilities" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:Panel ID="pnlUtility" runat="server" BorderStyle="Groove">
        <h4>
            Đặc điểm & Tiện ích
        </h4>
        <asp:Table ID="tblUtility" runat="server" GridLines="Both">
            <asp:TableRow>
                <asp:TableCell>
                    <b>Tình trạng pháp lý:</b><br />
                    <asp:DropDownList ID="ddlLegal" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>Sổ hồng</asp:ListItem>
                        <asp:ListItem>Giấy đỏ</asp:ListItem>
                        <asp:ListItem>Giấy tay</asp:ListItem>
                        <asp:ListItem>Đang hợp thức hóa</asp:ListItem>
                        <asp:ListItem>Giấy tờ hợp lệ</asp:ListItem>
                        <asp:ListItem>Chủ quyền tư nhân</asp:ListItem>
                        <asp:ListItem>Hợp đồng</asp:ListItem>
                        <asp:ListItem>Không xác định</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <b>Số phòng khách:</b><br />
                    <asp:DropDownList ID="ddlLivingRoom" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell RowSpan="4">
                    <b>Các tiện ích:</b><br />
                    <asp:CheckBoxList ID="cblUtility" runat="server"
                        DataSourceID="dataSourceUtility"
                        DataTextField="Name"
                        DataValueField="ID"></asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Hướng tài sản:</b><br />
                    <asp:DropDownList ID="ddlDirection" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>Đông</asp:ListItem>
                        <asp:ListItem>Tây</asp:ListItem>
                        <asp:ListItem>Nam</asp:ListItem>
                        <asp:ListItem>Bắc</asp:ListItem>
                        <asp:ListItem>Đông Bắc</asp:ListItem>
                        <asp:ListItem>Đông Nam</asp:ListItem>
                        <asp:ListItem>Tây Bắc</asp:ListItem>
                        <asp:ListItem>Tây Nam</asp:ListItem>
                        <asp:ListItem>Không xác định</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <b>Số phòng ngủ:</b><br />
                    <asp:DropDownList ID="ddlBedRoom" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>61</asp:ListItem>
                        <asp:ListItem>62</asp:ListItem>
                        <asp:ListItem>63</asp:ListItem>
                        <asp:ListItem>64</asp:ListItem>
                        <asp:ListItem>65</asp:ListItem>
                        <asp:ListItem>66</asp:ListItem>
                        <asp:ListItem>67</asp:ListItem>
                        <asp:ListItem>68</asp:ListItem>
                        <asp:ListItem>69</asp:ListItem>
                        <asp:ListItem>70</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Đường trước nhà:</b><br />
                    <asp:DropDownList ID="ddlFrontStreet" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>< 3m</asp:ListItem>
                        <asp:ListItem>> 3m</asp:ListItem>
                        <asp:ListItem>> 4m</asp:ListItem>
                        <asp:ListItem>> 5m</asp:ListItem>
                        <asp:ListItem>> 6m</asp:ListItem>
                        <asp:ListItem>> 7m</asp:ListItem>
                        <asp:ListItem>> 8m</asp:ListItem>
                        <asp:ListItem>> 9m</asp:ListItem>
                        <asp:ListItem>> 10m</asp:ListItem>
                        <asp:ListItem>> 15m</asp:ListItem>
                        <asp:ListItem>> 20m</asp:ListItem>
                        <asp:ListItem>> 40m</asp:ListItem>
                        <asp:ListItem>> 60m</asp:ListItem>
                        <asp:ListItem>> 80m</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <b>Số phòng tắm/vệ sinh:</b><br />
                    <asp:DropDownList ID="ddlBathRoom" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>61</asp:ListItem>
                        <asp:ListItem>62</asp:ListItem>
                        <asp:ListItem>63</asp:ListItem>
                        <asp:ListItem>64</asp:ListItem>
                        <asp:ListItem>65</asp:ListItem>
                        <asp:ListItem>66</asp:ListItem>
                        <asp:ListItem>67</asp:ListItem>
                        <asp:ListItem>68</asp:ListItem>
                        <asp:ListItem>69</asp:ListItem>
                        <asp:ListItem>70</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Số lầu:</b><br />
                    <asp:DropDownList ID="ddlStorey" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>61</asp:ListItem>
                        <asp:ListItem>62</asp:ListItem>
                        <asp:ListItem>63</asp:ListItem>
                        <asp:ListItem>64</asp:ListItem>
                        <asp:ListItem>65</asp:ListItem>
                        <asp:ListItem>66</asp:ListItem>
                        <asp:ListItem>67</asp:ListItem>
                        <asp:ListItem>68</asp:ListItem>
                        <asp:ListItem>69</asp:ListItem>
                        <asp:ListItem>70</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <b>Số phòng khác:</b><br />
                    <asp:DropDownList ID="ddlOtherRoom" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <asp:Panel ID="pnlDescription" runat="server" BorderStyle="Groove">
        <h4>Mô tả chi tiết tài sản</h4>
        <asp:Label ID="lbl" runat="server" ForeColor="Red">
            Vùng nội dung mô tả này sẽ được kiểm duyệt thông tin trước khi cho phép hiển thị trên RealEstateMarket.vn 
        </asp:Label>
        <br />
        Tin đăng nhập nội dung theo đúng quy định sẽ được ưu tiên duyệt hiển thị nhanh hơn.
        Vui lòng nhập tiếng Việt có dấu. Nếu bạn không nhập mô tả, hệ thống sẽ lấy mô tả tự động.
        <br />
        <asp:Table ID="tblDescription" runat="server" GridLines="Both">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right"><b>Tiêu đề:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxTitle" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right"><b>Nội dung mô tả:</b></asp:TableCell>
                <asp:TableCell>
                    <CKEditor:CKEditorControl ID="editor" runat="server"></CKEditor:CKEditorControl>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right"><b>Bộ gõ Tiếng Việt:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="rblKey" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>VNI</asp:ListItem>
                        <asp:ListItem>TELEX</asp:ListItem>
                        <asp:ListItem>Tắt bộ gõ</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:Panel ID="pnlImage" runat="server" BorderStyle="Groove">
        <h4>Cập nhật hình ảnh</h4>
        <asp:Label ID="lbl2" runat="server" ForeColor="Blue" Text="Cập nhật hình ảnh tài sản: (Tối đa 10 hình)"></asp:Label><br />
        <asp:FileUpload ID="fuImage" runat="server" />
        <br />
        - Không đăng các hình ảnh mờ hoặc hình có kích thước nhỏ hơn 360x300 pixel.<br />
        - Không đăng các hình ảnh có gắn kèm logo hoặc thông điệp quảng cáo.<br />
        - Nếu bạn không tải hình ảnh, hệ thống sẽ lấy hình minh hoạ tự động tương ứng với loại địa ốc mà bạn chọn.
    </asp:Panel>
    <asp:Panel ID="pnlMap" runat="server" BorderStyle="Groove">
        <h4>Cập nhật vị trí Địa ốc trên bản đồ</h4>
        <asp:ImageButton ID="imgButtonMap" runat="server" />
        Click vào đây để tiến hành cập nhật vị trí tài sản trên bản đồ
        Tài sản của quý vị sẽ được giao dịch nhanh hơn khi cập nhật vị trí chính xác của tài sản
    </asp:Panel>
    <asp:Panel ID="pnlContact" runat="server" BorderStyle="Groove">
        <asp:Table runat="server" ID="tblContact">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblContactName" runat="server" Text="Người liên hệ:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxContactName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblContactHomePhone" runat="server" Text="Điện thoại:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxContactHomePhone" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblContactPhone" runat="server" Text="Di động:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxContactPhone" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblContactAddress" runat="server" Text="Địa chỉ:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <nixforest:address ID="addressContact" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblContactNote" runat="server" Text="Ghi chú:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbxContactNote" TextMode="MultiLine" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <asp:Panel ID="pnlNote" runat="server" BorderStyle="Groove" HorizontalAlign="Center">
        Những mục có dấu * là thông tin phải điền đầy đủ. Chỉ khi bạn hoàn tất những thông tin được yêu cầu 
        điền đầy đủ thì các chức năng Xem trước hay Đăng tài sản mới được kích hoạt
        RealEstateMarket không chịu trách nhiệm về những nội dung (chữ/ hình ảnh/ Video) do bạn đăng tải
        Khi nhấn nút đăng tài sản, bạn đã xác nhận hoàn toàn đồng ý với những Điều khoản đăng tin.
        <br />
        <asp:Button ID="btnPreview" runat="server" Text="Xem trước" />
        <asp:Button ID="btnSave" runat="server" Text="Lưu lại" />
        <asp:Button ID="btnPost" runat="server" Text="Đăng tài sản" OnClick="btnPost_Click"/>
    </asp:Panel>
</asp:Content>
