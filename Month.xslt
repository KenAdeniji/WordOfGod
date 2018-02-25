<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!-- 
 Created:  20031217. 3rd Month (Exodus 19:1, 1 Chronicles 27:5, 2 Chronicles 15:10, 2 Chronicles 31:7, Esther 8:9, Ezekiel 31:1, Ezekiel 23, Ezekiel 31).
                     5th Month. Disk 2 of 3.
                     7th Month. Disk 3 of 3 (2 Kings 25:25).
                     9th Month. Disk 1 of 3 (1 Chronicles 27:12, Ezra 10:9, Jeremiah 36:9, Jeremiah 36:22, Haggai 2:10, Haggai 2:18, Zechariah 7:1).
-->

<xsl:output method="html" indent="no" />
 <xsl:template match="/">
  <html>
   <body>
    <table align="center" border="1">
     <theader>
      <tr align="center"><td colspan="3">
        Sign
        (
         <a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Genesis+1%3A14-19%2C+Revelation+8%3A12&amp;section=0&amp;version=nkj&amp;language=en">
          Genesis 1:14-19, Revelation 8:12
         </a>
        )
      </td></tr>
      <tr align="center">
       <td>Month</td>
       <td>Title</td>       
       <td>ScriptureReference</td>
      </tr>
     </theader>     
     <tbody>
      <xsl:apply-templates select="/Month/Month">
       <xsl:sort select="Sign" data-type="number" order="ascending" case-order="lower-first"/>
       <xsl:sort select="position()" data-type="number" order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </tbody>
    </table>
  </body>
 </html>
 </xsl:template>

 <xsl:template match="/Month/Month">
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
       <xsl:value-of select="Title"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Title"/>
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
   <td>
    <xsl:value-of select="Commentary"/>
   </td>
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
