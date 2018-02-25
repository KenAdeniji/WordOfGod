<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!-- 
 Created:    20031214
-->

<xsl:output method="html" indent="no" />

 <xsl:variable 
  name="ScriptureReference1" 
  select="/Eternal/Eternal[SequenceOrderId=1]/ScriptureReference"
 />

 <xsl:variable 
  name="ScriptureReference2" 
  select="/Eternal/Eternal[SequenceOrderId=2]/ScriptureReference"
 />

 <xsl:variable 
  name="ScriptureReference3" 
  select="/Eternal/Eternal[SequenceOrderId=3]/ScriptureReference"
 />

 <xsl:variable 
  name="ScriptureReference4" 
  select="/Eternal/Eternal[SequenceOrderId=4]/ScriptureReference"
 />

 <xsl:variable 
  name="ScriptureReferenceURI1" 
  select="/Eternal/Eternal[SequenceOrderId=1]/ScriptureReferenceURI"
 />

 <xsl:variable 
  name="ScriptureReferenceURI2" 
  select="/Eternal/Eternal[SequenceOrderId=2]/ScriptureReferenceURI"
 />

 <xsl:variable 
  name="ScriptureReferenceURI3" 
  select="/Eternal/Eternal[SequenceOrderId=3]/ScriptureReferenceURI"
 />

 <xsl:variable 
  name="ScriptureReferenceURI4" 
  select="/Eternal/Eternal[SequenceOrderId=4]/ScriptureReferenceURI"
 />

 <xsl:variable name="documentTribe" select="document('Tribe.xml')//entry"/>
 <xsl:variable name="documentEternal" select="document('Eternal.xml')/Eternal/Eternal"/> 

 <xsl:template name="tribe">
   <xsl:for-each select="$documentTribe">
    <xsl:variable name="tribe" select="@id"/>
    <tr align="center">
     <td align="left"><xsl:value-of select="$tribe"/></td>
      <xsl:for-each select="$documentEternal">
       <xsl:variable name="scriptureReferenceURI" select="ScriptureReferenceURI"/>
       <td align="right"><a target="_blank" href="{$scriptureReferenceURI}">
        <xsl:choose>
         <xsl:when test="$tribe='Reuben'"><xsl:value-of select="Reuben"/></xsl:when>
         <xsl:when test="$tribe='Simeon'"><xsl:value-of select="Simeon"/></xsl:when>
         <xsl:when test="$tribe='Levi'"><xsl:value-of select="Levi"/></xsl:when>
         <xsl:when test="$tribe='Judah'"><xsl:value-of select="Judah"/></xsl:when>
         <xsl:when test="$tribe='Issachar'"><xsl:value-of select="Issachar"/></xsl:when>
         <xsl:when test="$tribe='Zebulun'"><xsl:value-of select="Zebulun"/></xsl:when>
         <xsl:when test="$tribe='Gad'"><xsl:value-of select="Gad"/></xsl:when>
         <xsl:when test="$tribe='Asher'"><xsl:value-of select="Asher"/></xsl:when>         
         <xsl:when test="$tribe='Dan'"><xsl:value-of select="Dan"/></xsl:when>
         <xsl:when test="$tribe='Naphtali'"><xsl:value-of select="Naphtali"/></xsl:when>
         <xsl:when test="$tribe='Joseph'"><xsl:value-of select="Joseph"/></xsl:when>
         <xsl:when test="$tribe='Benjamin'"><xsl:value-of select="Benjamin"/></xsl:when>
         <xsl:when test="$tribe='Manasseh'"><xsl:value-of select="Manasseh"/></xsl:when>
         <xsl:when test="$tribe='Ephraim'"><xsl:value-of select="Ephraim"/></xsl:when>
         <xsl:otherwise/>
        </xsl:choose>
       </a></td>
      </xsl:for-each>
    </tr>
   </xsl:for-each>
   <tr align="center">
    <td align="left">Total</td>
    <xsl:for-each select="$documentEternal">
     <xsl:variable name="scriptureReferenceURI" select="ScriptureReferenceURI"/>
     <td align="right">
      <a target="_blank" href="{$scriptureReferenceURI}">
       <xsl:value-of select="Eternal"/>
      </a> 
     </td>
    </xsl:for-each>     
   </tr>    
 </xsl:template>

 <xsl:template match="/">
  <html>
   <body>
    <table align="center" border="1">
     <theader>
      <tr align="center"><td colspan="5">
        El Olam God of Eternity 
        (
         <a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Genesis+21%3A33&amp;section=0&amp;version=nkj&amp;language=en">
          Genesis 21:33
         </a>
        )
       </td></tr>
      <tr>
       <td>Tribe</td>
       <td>Abraham's Reward</td>
       <td>First Census</td>
       <td>Second Census</td>
       <td>Servant's Seal</td>
      </tr>       
     </theader>     
     <tbody>
      <xsl:call-template name="tribe"/>
     </tbody>
    </table>
    <br/><br/>
    <table align="center" border="1">
     <theader>
      <tr align="center"><td colspan="22">
        El Olam God of Eternity 
        (
         <a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Genesis+21%3A33&amp;section=0&amp;version=nkj&amp;language=en">
          Genesis 21:33
         </a>
        )
       </td></tr>
      <tr align="center">
       <td>No.</td>
       <td>Title</td>
       <td>Reuben</td>
       <td>Simeon</td>
       <td>Levi</td>
       <td>Judah</td>
       <td>Issachar</td>
       <td>Zebulun</td>
       <td>Gad</td>
       <td>Asher</td>
       <td>Dan</td>
       <td>Naphtali</td>
       <td>Joseph</td>
       <td>Benjamin</td>
       <td>Manasseh</td>
       <td>Ephraim</td>
       <td>Leah</td>
       <td>Rachel</td>
       <td>Zilpah</td>
       <td>Bilhah</td>
       <td>Eternal</td>
       <td>Scripture Reference</td>
      </tr>
     </theader>     
     <tbody>
      <xsl:apply-templates select="/Eternal/Eternal">
       <xsl:sort select="SequenceOrderId" data-type="number" order="ascending" case-order="lower-first"/>
       <xsl:sort select="position()" data-type="number" order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </tbody>
    </table>
  </body>
 </html>
 </xsl:template>

 <xsl:template match="/Eternal/Eternal">
  <tr align="center">
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="SequenceOrderId"/></a></td>
   <td align="left"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Title"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Reuben"/></a></td>   
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Simeon"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Levi"/></a></td>   
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Judah"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Issachar"/></a></td>   
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Zebulun"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Gad"/></a></td>   
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Asher"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Dan"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Naphtali"/></a></td>   
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Joseph"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Benjamin"/></a></td>   
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Manasseh"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Ephraim"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Leah"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Rachel"/></a></td>   
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Zilpah"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Bilhah"/></a></td>   
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="Eternal"/></a></td>
   <td align="right"><a target="_blank" href="{ScriptureReferenceURI}"><xsl:value-of select="ScriptureReference"/></a></td>
  </tr>
 </xsl:template>

</xsl:stylesheet>

<!--
Legal filter operators are:
 =    (equal) 
 !=   (not equal) 
 &lt; less than 
 &gt; greater than
-->

<!--
HTML Special Entities
Character   Meaning        Entity   Numeric
<           Less than      &lt;     &#60;
>           Greater than   &gt;     &#62;
&           Ampersand      &amp;    &#38;
'           Apostrophe     &apos;   &#39;
"           Quote          &quot;   &#34;
-->