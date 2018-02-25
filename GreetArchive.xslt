<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!-- 
 Created:  20030630 Greet.xml
-->

<xsl:output method="html" indent="no" />
 <xsl:template match="/">
  <html>
   <body>
    <table align="center" border="1">
     <theader>
      <tr align="center"><td colspan="9">
        Sign
        (
         <a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Genesis+1%3A14-19%2C+Revelation+8%3A12&amp;section=0&amp;version=nkj&amp;language=en">
          Genesis 1:14-19, Revelation 8:12
         </a>
        ).
      </td></tr>
      <tr align="center"><td colspan="9">
        Adam said, This is now bone of my bones, and flesh of my flesh: she shall be called Woman, because she was taken out of Man. Therefore shall a man leave his father and his mother, and shall cleave unto his wife: and they shall be one flesh
        (
         <a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Genesis+2%3A23-24&amp;section=0&amp;version=nkj&amp;language=en">
          Genesis 2:23-24
         </a>
        ).
      </td></tr>
      <tr align="center">
       <td>Sign</td>
       <td>ScriptureReference</td>
       <td>Sender</td>
       <td>Ambassador</td>
       <!-- <td>Ambassador Population</td> -->
       <td>Recipient</td>
       <!-- <td>Audience</td> -->
       <td>Saying</td>       
       <td>Classification</td>
      </tr>
     </theader>     
     <tbody>
      <xsl:apply-templates select="/Greet/Greet">
       <xsl:sort select="Sign" data-type="number" order="ascending" case-order="lower-first"/>
       <xsl:sort select="position()" data-type="number" order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </tbody>
    </table>
  </body>
 </html>
 </xsl:template>

 <xsl:template match="/Greet/Greet">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Sign"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Sign"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Sender"/></td>
   <td><xsl:value-of select="Ambassador"/></td>
   <!-- <td><xsl:value-of select="AmbassadorPopulation"/></td> -->
   <td><xsl:value-of select="Recipient"/></td>
   <!-- <td><xsl:value-of select="Audience"/></td> -->
   <td><xsl:value-of select="Saying"/></td>
   <td><xsl:value-of select="Classification"/></td>
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